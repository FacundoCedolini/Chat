// Forms/MainForm.cs
using Chat.Models;
using Chat.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System.Drawing.Drawing2D;
using System;
using System.Windows.Forms;
using Chat.Data;

namespace Chat.Forms
{
    public partial class MainForm : Form
    {
        private HubConnection _connection;
        private readonly UserService _userService;
        private User _currentUser;
        private string? _currentChatUser = null;
        private List<User> _allUsers = new();
        private HashSet<string> _connectedUsers = new();
        private HashSet<string> _usuariosConMensajesNoLeidos = new();


        public MainForm()
        {
            InitializeComponent();
            InitSignalR();
        }

        public MainForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
            InitSignalR();
        }

        public MainForm(User currentUser)
        {
            InitializeComponent();
            listBoxUsers.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxUsers.DrawItem += listBoxUsers_DrawItem;
            _currentUser = currentUser;
            this.Text = $"Chat - Bienvenido {_currentUser.Username}";

            using (var db = new AppDbContext())
            {
                var userService = new UserService(db);
                _allUsers = userService.GetAllUsers();
            }

            InitSignalR();

            UIUtils.RedondearBoton(btnSend);
            UIUtils.RedondearBoton(btnVolverGeneral);
            UIUtils.RedondearBoton(btnCerrarSesion);
        }

        private async void InitSignalR()
        {
            _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/chathub?username=" + _currentUser.Username)
            .Build();

            _connection.On<string, string, string>("ReceiveMessage", (user, toUser, message) =>
            {
                Invoke(() =>
                {
                    bool isGeneral = string.IsNullOrWhiteSpace(_currentChatUser);

                    if (isGeneral && string.IsNullOrWhiteSpace(toUser))
                    {
                        // Mensajes generales en el chat general
                        string fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        rtbMessages.AppendText($"[{fechaHora}] {user}: {message}{Environment.NewLine}");
                    }
                    else if (
                        !isGeneral &&
                        !string.IsNullOrWhiteSpace(toUser) && // Mensajes privados
                        (
                            // Mensaje enviado por el usuario seleccionado hacia mí
                            (user == _currentChatUser && toUser == _currentUser.Username)
                            ||
                            // Mensaje enviado por mí hacia el usuario seleccionado
                            (user == _currentUser.Username && toUser == _currentChatUser)
                        )
                    )
                    {
                        string fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        rtbMessages.AppendText($"[{fechaHora}] {user}: {message}{Environment.NewLine}");
                    }

                    // Si recibo un mensaje privado, se marca como no leido
                    if (isGeneral && !string.IsNullOrWhiteSpace(toUser) && toUser == _currentUser.Username)
                    {
                        _usuariosConMensajesNoLeidos.Add(user);
                        UpdateUserList();
                    }

                    rtbMessages.SelectionStart = rtbMessages.TextLength;
                    rtbMessages.ScrollToCaret();
                });
            });

            _connection.On<List<string>>("UsersUpdated", (users) =>
            {
                Invoke(() =>
                {
                    _connectedUsers = users.Where(u => u != _currentUser.Username).ToHashSet();
                    UpdateUserList();
                });
            });


            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrWhiteSpace(message))
                return;

            string toUser = _currentChatUser ?? ""; // "" para general

            try
            {
                await _connection.InvokeAsync("SendMessage", toUser, message);
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar mensaje: {ex.Message}");
            }
        }

        private async void btnVolverGeneral_Click(object? sender, EventArgs e)
        {
            _currentChatUser = null;
            btnVolverGeneral.Visible = false;
            await LoadMessages();
            listBoxUsers.ClearSelected();
        }

        private async void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (_connection != null)
            {
                try
                {
                    await _connection.StopAsync();
                    await _connection.DisposeAsync();
                }
                catch { /**/ }
            }
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(btnSend, EventArgs.Empty);
            }
        }

        private void listBoxUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var user = (User)listBoxUsers.Items[e.Index];
            bool conectado = _connectedUsers.Contains(user.Username);
            bool tieneNoLeidos = _usuariosConMensajesNoLeidos.Contains(user.Username);

            Color color;
            if (tieneNoLeidos)
                color = Color.DeepSkyBlue; // Azul para mensajes no leídos
            else if (conectado)
                color = Color.White;       // Blanco para conectados
            else
                color = Color.Gray;        // Gris para desconectados

            e.DrawBackground();
            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.DrawString(user.Username, e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }



        private async void MainForm_Load(object sender, EventArgs e)
        {
            userName.Text = _currentUser?.Username ?? "Usuario Desconocido";

            LoadMessages();
        }

        private async Task LoadUsers()
        {
            try
            {
                var users = await _connection.InvokeAsync<List<string>>("GetConnectedUsers");

                listBoxUsers.Items.Clear();
                foreach (var user in users)
                {
                    if (user != _currentUser.Username)
                        listBoxUsers.Items.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios conectados: " + ex.Message);
            }
        }

        private void UpdateUserList()
        {
            listBoxUsers.Items.Clear();

            // Usuarios con mensajes no leídos (azul)
            foreach (var user in _allUsers
                .Where(u => _usuariosConMensajesNoLeidos.Contains(u.Username) && u.Username != _currentUser.Username))
            {
                listBoxUsers.Items.Add(user);
            }

            // Usuarios conectados (blanco) que NO tienen mensajes no leídos
            foreach (var user in _allUsers
                .Where(u => _connectedUsers.Contains(u.Username)
                    && !_usuariosConMensajesNoLeidos.Contains(u.Username)
                    && u.Username != _currentUser.Username))
            {
                listBoxUsers.Items.Add(user);
            }

            // Usuarios desconectados (gris) que NO tienen mensajes no leídos
            foreach (var user in _allUsers
                .Where(u => !_connectedUsers.Contains(u.Username)
                    && !_usuariosConMensajesNoLeidos.Contains(u.Username)
                    && u.Username != _currentUser.Username))
            {
                listBoxUsers.Items.Add(user);
            }
        }


        private async Task LoadMessages(string? withUser = null)
        {
            try
            {
                rtbMessages.Clear();

                var messages = await _connection.InvokeAsync<List<Models.Message>>("GetMessageHistory", withUser);

                foreach (var msg in messages.OrderBy(m => m.Timestamp))
                {
                    string fechaHora = msg.Timestamp.ToString("dd/MM/yyyy HH:mm");
                    rtbMessages.AppendText($"[{fechaHora}] {msg.FromUsername}: {msg.Content}{Environment.NewLine}");
                }
                rtbMessages.SelectionStart = rtbMessages.TextLength;
                rtbMessages.ScrollToCaret();

                btnVolverGeneral.Visible = !string.IsNullOrWhiteSpace(withUser);

                if (string.IsNullOrWhiteSpace(withUser))
                {
                    label2.Text = "General";
                    label2.Visible = true;
                }
                else
                {
                    label2.Text = withUser;
                    label2.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mensajes: " + ex.Message);
            }
        }

        private async void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedUser = (listBoxUsers.SelectedItem as User)?.Username;
            if (!string.IsNullOrWhiteSpace(selectedUser))
            {
                _currentChatUser = selectedUser;
                _usuariosConMensajesNoLeidos.Remove(selectedUser);
                UpdateUserList();
                btnVolverGeneral.Visible = true;
                await LoadMessages(_currentChatUser);
            }

        }
    }
}


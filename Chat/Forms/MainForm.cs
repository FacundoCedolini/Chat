// Forms/MainForm.cs
using Chat.Models;
using Chat.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Windows.Forms;

namespace Chat.Forms
{
    public partial class MainForm : Form
    {
        private HubConnection _connection;
        private readonly UserService _userService;

        private User _currentUser;
        private string? _currentChatUser = null;


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
            _currentUser = currentUser;
            this.Text = $"Chat - Bienvenido {_currentUser.Username}";
            InitSignalR();
        }


        private async void InitSignalR()
        {
            _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/chathub?username=" + _currentUser.Username)
            .Build();

            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Invoke(() =>
                {
                    string tag = string.IsNullOrWhiteSpace(txtToUser.Text) ? "[General]" : "[Privado]";
                    listBoxMessages.Items.Add($"{tag} {user}: {message}");
                });
            });

            _connection.On<List<string>>("UsersUpdated", (users) =>
            {
                Invoke(() =>
                {
                    listBoxUsers.Items.Clear();
                    foreach (var user in users)
                    {
                        if (user != _currentUser.Username)
                            listBoxUsers.Items.Add(user);
                    }
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

        private async Task LoadMessages(string? withUser = null)
        {
            try
            {
                listBoxMessages.Items.Clear();

                var messages = await _connection.InvokeAsync<List<Models.Message>>("GetMessageHistory", withUser);

                foreach (var msg in messages.OrderBy(m => m.Timestamp))
                {
                    string tag = string.IsNullOrWhiteSpace(msg.ToUsername) ? "[General]" : "[Privado]";
                    listBoxMessages.Items.Add($"{tag} {msg.FromUsername}: {msg.Content}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mensajes: " + ex.Message);
            }
        }

        private async void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedUser = listBoxUsers.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedUser))
            {
                _currentChatUser = selectedUser;
                await LoadMessages(_currentChatUser);
            }
        }
    }
}


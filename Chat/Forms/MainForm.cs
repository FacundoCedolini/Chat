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
            string toUser = txtToUser.Text.Trim(); // El destinatario (si hay)
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
                return;

            try
            {
                await _connection.InvokeAsync("SendMessage", toUser, message);
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            userName.Text = _currentUser?.Username ?? "Usuario Desconocido";

            try
            {
                var history = await _connection.InvokeAsync<List<Models.Message>>("GetMessageHistory", (string?)null);

                foreach (var msg in history)
                {
                    listBoxMessages.Items.Add($"{msg.FromUsername}: {msg.Content}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando historial: " + ex.Message);
            }
        }
    }
}


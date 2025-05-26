// Forms/MainForm.cs
using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.Forms
{
    public partial class MainForm : Form
    {
        private HubConnection _connection;

        public MainForm()
        {
            InitializeComponent();
            InitSignalR();
        }

        private async void InitSignalR()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatHub")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Invoke(() =>
                {
                    listBoxMessages.Items.Add($"{user}: {message}");
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
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            try
            {
                await _connection.InvokeAsync("SendMessage", txtUser.Text, txtMessage.Text);
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }
    }
}


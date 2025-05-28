using Chat.Data;
using Chat.Models;
using Chat.Services;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Chat.Forms
{
    public partial class LoginForm : Form
    {
        public User? LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            using var db = new AppDbContext();
            var userService = new UserService(db);

            var user = userService.GetUser(username, password);
            if (user == null)
            {
                MessageBox.Show("Credenciales inválidas.");
                return;
            }

            LoggedInUser = user;
            MessageBox.Show($"Bienvenido, {username}!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}

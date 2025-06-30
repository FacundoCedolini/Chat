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
            UIUtils.RedondearBoton(btnLogin);
            UIUtils.RedondearBoton(btnRegister);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                new ErrorForm("Debe completar todos los campos.").ShowDialog();
                return;
            }

            using var db = new AppDbContext();
            var userService = new UserService(db);

            var user = userService.GetUser(username, password);
            if (user == null)
            {
                new ErrorForm("Credenciales invalidas").ShowDialog();
                return;
            }

            LoggedInUser = user;
            this.Hide();
            var welcome = new WelcomeForm(LoggedInUser);
            welcome.ShowDialog();
            this.Close();


        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

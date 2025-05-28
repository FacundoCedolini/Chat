using Chat.Data;
using Chat.Models;
using Chat.Services;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Chat.Forms
{
    public partial class RegisterForm : Form
    {

        private readonly UserService _userService;

        public RegisterForm()
        {
            InitializeComponent();
            _userService = new UserService(new AppDbContext());
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            var success = _userService.Register(username, password);

            if (success)
            {
                MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.");
                this.Close();
            }
            else
            {
                MessageBox.Show("El nombre de usuario ya está en uso. Por favor, elija otro.");
            }
        }
    }
}

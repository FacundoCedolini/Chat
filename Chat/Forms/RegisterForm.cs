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
            UIUtils.RedondearBoton(btnRegister);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            var email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                new ErrorForm("Debe completar todos los campos.").ShowDialog();
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                new ErrorForm("El email ingresado no es válido.").ShowDialog();
                return;
            }

            var success = _userService.Register(username, password, email);

            if (success)
            {
                new SuccessForm("Registro exitoso. Ahora puede iniciar sesión.").ShowDialog();
                this.Close();
            }
            else
            {
                new ErrorForm("El nombre de usuario o email ya está en uso. Por favor, elija otro.").ShowDialog();

            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

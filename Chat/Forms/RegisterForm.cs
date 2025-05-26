using Chat.Data;
using Chat.Models;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Chat.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
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

            using (var db = new AppDbContext())
            {
                if (db.Users.Any(u => u.Username == username))
                {
                    MessageBox.Show("El nombre de usuario ya existe.");
                    return;
                }

                var user = new User
                {
                    Username = username,
                    PasswordHash = ComputeSha256Hash(password)
                };

                db.Users.Add(user);
                db.SaveChanges();

                MessageBox.Show("Usuario registrado con éxito.");
                this.Close();
            }
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            var builder = new StringBuilder();
            foreach (var b in bytes)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
}

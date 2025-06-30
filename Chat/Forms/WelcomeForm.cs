using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Chat.Models;


namespace Chat.Forms
{
    public partial class WelcomeForm : Form
    {
        private User _currentUser;
        public WelcomeForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            lblWelcome.Text = $"¡Bienvenido, {_currentUser.Username}!";
            UIUtils.RedondearBoton(btnOk);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main = new MainForm(_currentUser);
            main.ShowDialog();
            this.Close();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}

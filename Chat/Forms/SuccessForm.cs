using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat.Models;

namespace Chat.Forms
{
    public partial class SuccessForm : Form
    {
        public SuccessForm(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
            UIUtils.RedondearBoton(btnOk);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

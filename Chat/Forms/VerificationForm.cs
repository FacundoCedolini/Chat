using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.Forms
{
    public partial class VerificationForm : Form
    {
        private readonly string _expectedCode;
        public string EnteredCode => txtCode.Text.Trim();

        public VerificationForm(string expectedCode)
        {
            InitializeComponent();
            _expectedCode = expectedCode;
            UIUtils.RedondearBoton(btnVerify);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                new ErrorForm("Debe ingresar el codigo").ShowDialog();
                return;
            }
            if (EnteredCode != _expectedCode)
            {
                new ErrorForm("Codigo incorrecto").ShowDialog();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnVerify_Click(btnVerify, EventArgs.Empty);
            }
        }
    }
}



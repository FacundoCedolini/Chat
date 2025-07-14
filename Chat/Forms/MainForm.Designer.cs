// Forms/MainForm.Designer.cs
namespace Chat.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnVolverGeneral;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnCerrarSesion;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtMessage = new TextBox();
            btnSend = new Button();
            rtbMessages = new RichTextBox();
            lblUser = new Label();
            lblMessage = new Label();
            userName = new Label();
            listBoxUsers = new ListBox();
            label1 = new Label();
            btnVolverGeneral = new Button();
            label2 = new Label();
            btnCerrarSesion = new Button();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.FromArgb(64, 68, 75);
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.ForeColor = Color.FromArgb(220, 221, 222);
            txtMessage.Location = new Point(90, 373);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(380, 30);
            txtMessage.TabIndex = 3;
            txtMessage.KeyDown += txtMessage_KeyDown;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(88, 101, 242);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(487, 373);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(110, 30);
            btnSend.TabIndex = 4;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // rtbMessages
            // 
            rtbMessages.BackColor = Color.FromArgb(47, 49, 54);
            rtbMessages.BorderStyle = BorderStyle.None;
            rtbMessages.Font = new Font("Segoe UI", 10F);
            rtbMessages.ForeColor = Color.FromArgb(220, 221, 222);
            rtbMessages.Location = new Point(12, 33);
            rtbMessages.Name = "rtbMessages";
            rtbMessages.ReadOnly = true;
            rtbMessages.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbMessages.Size = new Size(420, 260);
            rtbMessages.TabIndex = 5;
            rtbMessages.Text = "";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.ForeColor = Color.FromArgb(220, 221, 222);
            lblUser.Location = new Point(7, 347);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(72, 23);
            lblUser.TabIndex = 0;
            lblUser.Text = "Usuario:";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.FromArgb(220, 221, 222);
            lblMessage.Location = new Point(7, 375);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(77, 23);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Mensaje:";
            // 
            // userName
            // 
            userName.AutoSize = true;
            userName.ForeColor = Color.FromArgb(220, 221, 222);
            userName.Location = new Point(85, 347);
            userName.Name = "userName";
            userName.Size = new Size(55, 23);
            userName.TabIndex = 6;
            userName.Text = "label1";
            // 
            // listBoxUsers
            // 
            listBoxUsers.BackColor = Color.FromArgb(47, 49, 54);
            listBoxUsers.BorderStyle = BorderStyle.None;
            listBoxUsers.ForeColor = Color.FromArgb(220, 221, 222);
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.ItemHeight = 23;
            listBoxUsers.Location = new Point(460, 38);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(137, 253);
            listBoxUsers.TabIndex = 9;
            listBoxUsers.SelectedIndexChanged += listBoxUsers_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(220, 221, 222);
            label1.Location = new Point(442, 12);
            label1.Name = "label1";
            label1.Size = new Size(171, 23);
            label1.TabIndex = 10;
            label1.Text = "Usuarios conectados:";
            // 
            // btnVolverGeneral
            // 
            btnVolverGeneral.BackColor = Color.FromArgb(88, 101, 242);
            btnVolverGeneral.FlatAppearance.BorderSize = 0;
            btnVolverGeneral.FlatStyle = FlatStyle.Flat;
            btnVolverGeneral.ForeColor = Color.White;
            btnVolverGeneral.Location = new Point(487, 326);
            btnVolverGeneral.Name = "btnVolverGeneral";
            btnVolverGeneral.Size = new Size(110, 33);
            btnVolverGeneral.TabIndex = 11;
            btnVolverGeneral.Text = "Atras";
            btnVolverGeneral.UseVisualStyleBackColor = false;
            btnVolverGeneral.Visible = false;
            btnVolverGeneral.Click += btnVolverGeneral_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(220, 221, 222);
            label2.Location = new Point(12, 7);
            label2.Name = "label2";
            label2.Size = new Size(59, 23);
            label2.TabIndex = 12;
            label2.Text = "Label2";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(88, 101, 242);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(7, 311);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(146, 33);
            btnCerrarSesion.TabIndex = 13;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(626, 414);
            Controls.Add(btnCerrarSesion);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxUsers);
            Controls.Add(userName);
            Controls.Add(lblUser);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(rtbMessages);
            Controls.Add(btnVolverGeneral);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(220, 221, 222);
            Name = "MainForm";
            Text = "Chat Online";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Label userName;
        private ListBox listBoxUsers;
        private Label label1;
        private Label label2;
    }
}

// Forms/MainForm.Designer.cs
namespace Chat.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox listBoxMessages;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtUser = new TextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            listBoxMessages = new ListBox();
            lblUser = new Label();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // txtUser
            // 
            txtUser.Location = new Point(80, 15);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(200, 23);
            txtUser.TabIndex = 2;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(80, 50);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(400, 23);
            txtMessage.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(490, 50);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 4;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // listBoxMessages
            // 
            listBoxMessages.FormattingEnabled = true;
            listBoxMessages.ItemHeight = 15;
            listBoxMessages.Location = new Point(15, 90);
            listBoxMessages.Name = "listBoxMessages";
            listBoxMessages.Size = new Size(550, 244);
            listBoxMessages.TabIndex = 5;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(15, 18);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(50, 15);
            lblUser.TabIndex = 0;
            lblUser.Text = "Usuario:";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(15, 53);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(54, 15);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Mensaje:";
            // 
            // MainForm
            // 
            ClientSize = new Size(584, 361);
            Controls.Add(lblUser);
            Controls.Add(lblMessage);
            Controls.Add(txtUser);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(listBoxMessages);
            Name = "MainForm";
            Text = "Chat Online";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

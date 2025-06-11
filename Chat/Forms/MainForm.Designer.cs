// Forms/MainForm.Designer.cs
namespace Chat.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
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
            txtMessage = new TextBox();
            btnSend = new Button();
            listBoxMessages = new ListBox();
            lblUser = new Label();
            lblMessage = new Label();
            userName = new Label();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(75, 310);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(400, 23);
            txtMessage.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(487, 310);
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
            listBoxMessages.Location = new Point(12, 12);
            listBoxMessages.Name = "listBoxMessages";
            listBoxMessages.Size = new Size(550, 244);
            listBoxMessages.TabIndex = 5;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(12, 279);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(50, 15);
            lblUser.TabIndex = 0;
            lblUser.Text = "Usuario:";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(12, 313);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(54, 15);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Mensaje:";
            // 
            // userName
            // 
            userName.AutoSize = true;
            userName.Location = new Point(75, 279);
            userName.Name = "userName";
            userName.Size = new Size(38, 15);
            userName.TabIndex = 6;
            userName.Text = "label1";
            // 
            // MainForm
            // 
            ClientSize = new Size(584, 361);
            Controls.Add(userName);
            Controls.Add(lblUser);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(listBoxMessages);
            Name = "MainForm";
            Text = "Chat Online";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Label userName;
    }
}

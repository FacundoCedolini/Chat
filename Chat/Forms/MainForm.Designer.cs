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
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtUser
            this.txtUser.Location = new System.Drawing.Point(80, 15);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(200, 23);

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(80, 50);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(400, 23);

            // btnSend
            this.btnSend.Location = new System.Drawing.Point(490, 50);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // listBoxMessages
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.ItemHeight = 15;
            this.listBoxMessages.Location = new System.Drawing.Point(15, 90);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(550, 244);

            // lblUser
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(15, 18);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(47, 15);
            this.lblUser.Text = "Usuario:";

            // lblMessage
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(15, 53);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(58, 15);
            this.lblMessage.Text = "Mensaje:";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.listBoxMessages);
            this.Name = "MainForm";
            this.Text = "Chat Online";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

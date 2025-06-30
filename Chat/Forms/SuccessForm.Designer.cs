namespace Chat.Forms
{
    partial class SuccessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMessage = new Label();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMessage.ForeColor = Color.FromArgb(220, 221, 222);
            lblMessage.Location = new Point(38, 35);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(180, 28);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "¡Registro exitoso!";
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(88, 101, 242);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(182, 125);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // SuccessForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(463, 200);
            Controls.Add(btnOk);
            Controls.Add(lblMessage);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(220, 221, 222);
            Name = "SuccessForm";
            Text = "SuccessForm";
            ResumeLayout(false);
            PerformLayout();
            //Style
            this.BackColor = System.Drawing.Color.FromArgb(54, 57, 63);
            this.ForeColor = System.Drawing.Color.FromArgb(220, 221, 222);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

        }

        #endregion

        private Label lblMessage;
        private Button btnOk;
    }
}
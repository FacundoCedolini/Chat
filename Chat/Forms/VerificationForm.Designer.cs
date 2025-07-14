namespace Chat.Forms
{
    partial class VerificationForm
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
            lbl1 = new Label();
            txtCode = new TextBox();
            btnVerify = new Button();
            SuspendLayout();
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI", 11F);
            lbl1.ForeColor = Color.FromArgb(220, 221, 222);
            lbl1.Location = new Point(46, 49);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(319, 25);
            lbl1.TabIndex = 0;
            lbl1.Text = "Ingrese el código enviado a su email";
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(64, 68, 75);
            txtCode.BorderStyle = BorderStyle.FixedSingle;
            txtCode.Font = new Font("Segoe UI", 11F);
            txtCode.ForeColor = Color.FromArgb(220, 221, 222);
            txtCode.Location = new Point(90, 110);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(220, 32);
            txtCode.TabIndex = 1;
            txtCode.KeyDown += txtCode_KeyDown;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.FromArgb(88, 101, 242);
            btnVerify.FlatAppearance.BorderSize = 0;
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.Font = new Font("Segoe UI", 11F);
            btnVerify.ForeColor = Color.White;
            btnVerify.Location = new Point(137, 180);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(120, 35);
            btnVerify.TabIndex = 2;
            btnVerify.Text = "OK";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // VerificationForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(400, 250);
            Controls.Add(btnVerify);
            Controls.Add(txtCode);
            Controls.Add(lbl1);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(220, 221, 222);
            Name = "VerificationForm";
            Text = "Verificación de dos pasos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl1;
        private TextBox txtCode;
        private Button btnVerify;
    }
}
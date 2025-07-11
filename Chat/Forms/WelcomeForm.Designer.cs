﻿namespace Chat.Forms
{
    partial class WelcomeForm
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
            lblWelcome = new Label();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(220, 221, 222);
            lblWelcome.Location = new Point(37, 34);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(132, 28);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "¡Bienvenido!";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(88, 101, 242);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(80, 80);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 35);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(260, 140);
            Controls.Add(btnOk);
            Controls.Add(lblWelcome);
            ForeColor = Color.FromArgb(220, 221, 222);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bienvenido";
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnOk;


        #endregion

    }
}
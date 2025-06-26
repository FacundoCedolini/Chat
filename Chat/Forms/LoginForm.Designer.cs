namespace Chat.Forms
{
    partial class LoginForm
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            Usuario = new Label();
            Contraseña = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(64, 68, 75);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.FromArgb(220, 221, 222);
            txtUsername.Location = new Point(332, 136);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 30);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(64, 68, 75);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.FromArgb(220, 221, 222);
            txtPassword.Location = new Point(332, 225);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 30);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // Usuario
            // 
            Usuario.AutoSize = true;
            Usuario.ForeColor = Color.FromArgb(220, 221, 222);
            Usuario.Location = new Point(332, 101);
            Usuario.Name = "Usuario";
            Usuario.Size = new Size(68, 23);
            Usuario.TabIndex = 2;
            Usuario.Text = "Usuario";
            // 
            // Contraseña
            // 
            Contraseña.AutoSize = true;
            Contraseña.ForeColor = Color.FromArgb(220, 221, 222);
            Contraseña.Location = new Point(332, 192);
            Contraseña.Name = "Contraseña";
            Contraseña.Size = new Size(97, 23);
            Contraseña.TabIndex = 3;
            Contraseña.Text = "Contraseña";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(88, 101, 242);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(271, 311);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(108, 33);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Ingresar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(88, 101, 242);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(385, 311);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(102, 33);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Registrar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(Contraseña);
            Controls.Add(Usuario);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(220, 221, 222);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label Usuario;
        private Label Contraseña;
        private Button btnLogin;
        private Button btnRegister;
    }
}
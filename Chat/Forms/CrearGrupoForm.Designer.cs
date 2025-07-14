namespace Chat.Forms
{
    partial class CrearGrupoForm
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
            txtNombreGrupo = new TextBox();
            checkedListBoxUsuarios = new CheckedListBox();
            btnCrear = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtNombreGrupo
            // 
            txtNombreGrupo.BackColor = Color.FromArgb(64, 68, 75);
            txtNombreGrupo.BorderStyle = BorderStyle.FixedSingle;
            txtNombreGrupo.ForeColor = Color.FromArgb(220, 221, 222);
            txtNombreGrupo.Location = new Point(102, 49);
            txtNombreGrupo.Name = "txtNombreGrupo";
            txtNombreGrupo.Size = new Size(150, 27);
            txtNombreGrupo.TabIndex = 0;
            // 
            // checkedListBoxUsuarios
            // 
            checkedListBoxUsuarios.FormattingEnabled = true;
            checkedListBoxUsuarios.Location = new Point(102, 141);
            checkedListBoxUsuarios.Name = "checkedListBoxUsuarios";
            checkedListBoxUsuarios.Size = new Size(150, 114);
            checkedListBoxUsuarios.TabIndex = 1;
            checkedListBoxUsuarios.BackColor = Color.FromArgb(47, 49, 54);
            checkedListBoxUsuarios.ForeColor = Color.FromArgb(220, 221, 222);
            // 
            // btnCrear
            //
            btnCrear.BackColor = Color.FromArgb(88, 101, 242);
            btnCrear.FlatAppearance.BorderSize = 0;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCrear.ForeColor = Color.White;
            btnCrear.Location = new Point(131, 282);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(94, 29);
            btnCrear.TabIndex = 2;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(102, 26);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 3;
            label1.Text = "Nombre del grupo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 118);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 4;
            label2.Text = "Agregar a:";
            label2.Click += label2_Click;
            // 
            // CrearGrupoForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 323);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCrear);
            Controls.Add(checkedListBoxUsuarios);
            Controls.Add(txtNombreGrupo);
            Name = "CrearGrupoForm";
            Text = "CrearGrupoForm";
            BackColor = Color.FromArgb(54, 57, 63);
            ForeColor = Color.FromArgb(220, 221, 222);
            Font = new Font("Segoe UI", 10F);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreGrupo;
        private CheckedListBox checkedListBoxUsuarios;
        private Button btnCrear;
        private Label label1;
        private Label label2;
    }
}
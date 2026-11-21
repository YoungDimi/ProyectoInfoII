namespace Formularios
{
    partial class FormLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.entrarButton = new System.Windows.Forms.Button();
            this.registrarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(458, 162);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(100, 31);
            this.usuarioBox.TabIndex = 2;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(458, 208);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 31);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // entrarButton
            // 
            this.entrarButton.Location = new System.Drawing.Point(458, 262);
            this.entrarButton.Name = "entrarButton";
            this.entrarButton.Size = new System.Drawing.Size(96, 46);
            this.entrarButton.TabIndex = 4;
            this.entrarButton.Text = "Entrar";
            this.entrarButton.UseVisualStyleBackColor = true;
            this.entrarButton.Click += new System.EventHandler(this.entrarButton_Click);
            // 
            // registrarButton
            // 
            this.registrarButton.Location = new System.Drawing.Point(434, 378);
            this.registrarButton.Name = "registrarButton";
            this.registrarButton.Size = new System.Drawing.Size(152, 48);
            this.registrarButton.TabIndex = 5;
            this.registrarButton.Text = "Registrarse";
            this.registrarButton.UseVisualStyleBackColor = true;
            this.registrarButton.Click += new System.EventHandler(this.registrarButton_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 450);
            this.Controls.Add(this.registrarButton);
            this.Controls.Add(this.entrarButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button entrarButton;
        private System.Windows.Forms.Button registrarButton;
    }
}
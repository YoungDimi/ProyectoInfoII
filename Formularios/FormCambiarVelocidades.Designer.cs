namespace Formularios
{
    partial class FormCambiarVelocidades
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
            this.aplicarButton = new System.Windows.Forms.Button();
            this.tablaVelocidades = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaVelocidades)).BeginInit();
            this.SuspendLayout();
            // 
            // aplicarButton
            // 
            this.aplicarButton.Location = new System.Drawing.Point(258, 374);
            this.aplicarButton.Name = "aplicarButton";
            this.aplicarButton.Size = new System.Drawing.Size(287, 49);
            this.aplicarButton.TabIndex = 1;
            this.aplicarButton.Text = "Aplicar y reiniciar";
            this.aplicarButton.UseVisualStyleBackColor = true;
            this.aplicarButton.Click += new System.EventHandler(this.aplicarButton_Click);
            // 
            // tablaVelocidades
            // 
            this.tablaVelocidades.AllowUserToAddRows = false;
            this.tablaVelocidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaVelocidades.Location = new System.Drawing.Point(103, 57);
            this.tablaVelocidades.Name = "tablaVelocidades";
            this.tablaVelocidades.RowHeadersWidth = 82;
            this.tablaVelocidades.RowTemplate.Height = 33;
            this.tablaVelocidades.Size = new System.Drawing.Size(585, 298);
            this.tablaVelocidades.TabIndex = 2;
            // 
            // FormCambiarVelocidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tablaVelocidades);
            this.Controls.Add(this.aplicarButton);
            this.Name = "FormCambiarVelocidades";
            this.Text = "FormCambiarVelocidades";
            this.Load += new System.EventHandler(this.FormCambiarVelocidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaVelocidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button aplicarButton;
        private System.Windows.Forms.DataGridView tablaVelocidades;
    }
}
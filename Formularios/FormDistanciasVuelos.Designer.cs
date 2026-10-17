namespace Formularios
{
    partial class FormDistanciasVuelos
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
            this.IDsVuelosLabel = new System.Windows.Forms.Label();
            this.DistanciaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IDsVuelosLabel
            // 
            this.IDsVuelosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDsVuelosLabel.Location = new System.Drawing.Point(48, 20);
            this.IDsVuelosLabel.Name = "IDsVuelosLabel";
            this.IDsVuelosLabel.Size = new System.Drawing.Size(335, 38);
            this.IDsVuelosLabel.TabIndex = 0;
            this.IDsVuelosLabel.Text = "IDs de vuelos";
            this.IDsVuelosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DistanciaLabel
            // 
            this.DistanciaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DistanciaLabel.Location = new System.Drawing.Point(27, 78);
            this.DistanciaLabel.Name = "DistanciaLabel";
            this.DistanciaLabel.Size = new System.Drawing.Size(368, 24);
            this.DistanciaLabel.TabIndex = 1;
            this.DistanciaLabel.Text = "La distancia entre los dos vuelos es:";
            this.DistanciaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDistanciasVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 141);
            this.Controls.Add(this.DistanciaLabel);
            this.Controls.Add(this.IDsVuelosLabel);
            this.Name = "FormDistanciasVuelos";
            this.Text = "FormDistanciasVuelos";
            this.Load += new System.EventHandler(this.FormDistanciasVuelos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label IDsVuelosLabel;
        private System.Windows.Forms.Label DistanciaLabel;
    }
}
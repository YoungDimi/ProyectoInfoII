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
            this.tablaDistancias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDistancias)).BeginInit();
            this.SuspendLayout();
            // 
            // IDsVuelosLabel
            // 
            this.IDsVuelosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDsVuelosLabel.Location = new System.Drawing.Point(48, 25);
            this.IDsVuelosLabel.Name = "IDsVuelosLabel";
            this.IDsVuelosLabel.Size = new System.Drawing.Size(335, 38);
            this.IDsVuelosLabel.TabIndex = 0;
            this.IDsVuelosLabel.Text = "ID Vuelo";
            this.IDsVuelosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tablaDistancias
            // 
            this.tablaDistancias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDistancias.Location = new System.Drawing.Point(37, 92);
            this.tablaDistancias.Name = "tablaDistancias";
            this.tablaDistancias.RowHeadersWidth = 51;
            this.tablaDistancias.RowTemplate.Height = 24;
            this.tablaDistancias.Size = new System.Drawing.Size(346, 276);
            this.tablaDistancias.TabIndex = 1;
            // 
            // FormDistanciasVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 409);
            this.Controls.Add(this.tablaDistancias);
            this.Controls.Add(this.IDsVuelosLabel);
            this.Name = "FormDistanciasVuelos";
            this.Text = "FormDistanciasVuelos";
            this.Load += new System.EventHandler(this.FormDistanciasVuelos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDistancias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label IDsVuelosLabel;
        private System.Windows.Forms.DataGridView tablaDistancias;
    }
}
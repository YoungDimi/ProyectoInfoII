namespace Formularios
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introducirPlanesDeVueloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónDelSimuladorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.Size = new System.Drawing.Size(61, 4);
            this.MenuOpciones.Text = "Opciones";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introducirPlanesDeVueloToolStripMenuItem,
            this.configuraciónDelSimuladorToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // introducirPlanesDeVueloToolStripMenuItem
            // 
            this.introducirPlanesDeVueloToolStripMenuItem.Name = "introducirPlanesDeVueloToolStripMenuItem";
            this.introducirPlanesDeVueloToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.introducirPlanesDeVueloToolStripMenuItem.Text = "Introducir planes de vuelo";
            this.introducirPlanesDeVueloToolStripMenuItem.Click += new System.EventHandler(this.introducirPlanesDeVueloToolStripMenuItem_Click);
            // 
            // configuraciónDelSimuladorToolStripMenuItem
            // 
            this.configuraciónDelSimuladorToolStripMenuItem.Name = "configuraciónDelSimuladorToolStripMenuItem";
            this.configuraciónDelSimuladorToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.configuraciónDelSimuladorToolStripMenuItem.Text = "Configuración del simulador";
            this.configuraciónDelSimuladorToolStripMenuItem.Click += new System.EventHandler(this.configuraciónDelSimuladorToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MenuOpciones;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introducirPlanesDeVueloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónDelSimuladorToolStripMenuItem;
    }
}


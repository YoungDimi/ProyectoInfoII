namespace Formularios
{
    partial class FormEspacioAereo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEspacioAereo));
            this.autoTimer = new System.Windows.Forms.Timer(this.components);
            this.startAutoButton = new System.Windows.Forms.Button();
            this.stopAutoButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.avion1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eje_x = new System.Windows.Forms.Label();
            this.eje_y = new System.Windows.Forms.Label();
            this.moverButton = new System.Windows.Forms.Button();
            this.DatosVuelosButton = new System.Windows.Forms.Button();
            this.conflictosButton = new System.Windows.Forms.Button();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            this.cambiarVelocidadesButton = new System.Windows.Forms.Button();
            this.atrasButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avion1)).BeginInit();
            this.SuspendLayout();
            // 
            // autoTimer
            // 
            this.autoTimer.Interval = 1000;
            this.autoTimer.Tick += new System.EventHandler(this.AutoTimer_Tick);
            // 
            // startAutoButton
            // 
            this.startAutoButton.Location = new System.Drawing.Point(689, 169);
            this.startAutoButton.Margin = new System.Windows.Forms.Padding(2);
            this.startAutoButton.Name = "startAutoButton";
            this.startAutoButton.Size = new System.Drawing.Size(56, 21);
            this.startAutoButton.TabIndex = 4;
            this.startAutoButton.Text = "Iniciar Auto";
            this.startAutoButton.UseVisualStyleBackColor = true;
            this.startAutoButton.Click += new System.EventHandler(this.StartAutoButton_Click);
            // 
            // stopAutoButton
            // 
            this.stopAutoButton.Enabled = false;
            this.stopAutoButton.Location = new System.Drawing.Point(689, 198);
            this.stopAutoButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopAutoButton.Name = "stopAutoButton";
            this.stopAutoButton.Size = new System.Drawing.Size(56, 23);
            this.stopAutoButton.TabIndex = 5;
            this.stopAutoButton.Text = "Detener Auto";
            this.stopAutoButton.UseVisualStyleBackColor = true;
            this.stopAutoButton.Click += new System.EventHandler(this.StopAutoButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.avion1);
            this.panel1.Location = new System.Drawing.Point(75, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 416);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // avion1
            // 
            this.avion1.BackColor = System.Drawing.Color.Transparent;
            this.avion1.Image = ((System.Drawing.Image)(resources.GetObject("avion1.Image")));
            this.avion1.Location = new System.Drawing.Point(376, 120);
            this.avion1.Margin = new System.Windows.Forms.Padding(2);
            this.avion1.Name = "avion1";
            this.avion1.Size = new System.Drawing.Size(15, 15);
            this.avion1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avion1.TabIndex = 0;
            this.avion1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(292, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESPACIO AEREO.";
            // 
            // eje_x
            // 
            this.eje_x.AutoSize = true;
            this.eje_x.Location = new System.Drawing.Point(60, 288);
            this.eje_x.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.eje_x.Name = "eje_x";
            this.eje_x.Size = new System.Drawing.Size(13, 13);
            this.eje_x.TabIndex = 1;
            this.eje_x.Text = "0";
            // 
            // eje_y
            // 
            this.eje_y.AutoSize = true;
            this.eje_y.Location = new System.Drawing.Point(340, 501);
            this.eje_y.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.eje_y.Name = "eje_y";
            this.eje_y.Size = new System.Drawing.Size(13, 13);
            this.eje_y.TabIndex = 2;
            this.eje_y.Text = "0";
            // 
            // moverButton
            // 
            this.moverButton.Location = new System.Drawing.Point(668, 78);
            this.moverButton.Margin = new System.Windows.Forms.Padding(2);
            this.moverButton.Name = "moverButton";
            this.moverButton.Size = new System.Drawing.Size(98, 63);
            this.moverButton.TabIndex = 3;
            this.moverButton.Text = "Mover un ciclo";
            this.moverButton.UseVisualStyleBackColor = true;
            this.moverButton.Click += new System.EventHandler(this.moverButton_Click);
            // 
            // DatosVuelosButton
            // 
            this.DatosVuelosButton.Location = new System.Drawing.Point(678, 359);
            this.DatosVuelosButton.Margin = new System.Windows.Forms.Padding(2);
            this.DatosVuelosButton.Name = "DatosVuelosButton";
            this.DatosVuelosButton.Size = new System.Drawing.Size(77, 47);
            this.DatosVuelosButton.TabIndex = 6;
            this.DatosVuelosButton.Text = "Ver datos de los vuelos";
            this.DatosVuelosButton.UseVisualStyleBackColor = true;
            this.DatosVuelosButton.Click += new System.EventHandler(this.DatosVuelosButton_Click);
            // 
            // conflictosButton
            // 
            this.conflictosButton.Location = new System.Drawing.Point(668, 410);
            this.conflictosButton.Margin = new System.Windows.Forms.Padding(2);
            this.conflictosButton.Name = "conflictosButton";
            this.conflictosButton.Size = new System.Drawing.Size(98, 57);
            this.conflictosButton.TabIndex = 7;
            this.conflictosButton.Text = "Comprobar conflictos futuros";
            this.conflictosButton.UseVisualStyleBackColor = true;
            this.conflictosButton.Click += new System.EventHandler(this.conflictosButton_Click);
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.Location = new System.Drawing.Point(689, 234);
            this.buttonReiniciar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(56, 19);
            this.buttonReiniciar.TabIndex = 8;
            this.buttonReiniciar.Text = "Reiniciar";
            this.buttonReiniciar.UseVisualStyleBackColor = true;
            this.buttonReiniciar.Click += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // cambiarVelocidadesButton
            // 
            this.cambiarVelocidadesButton.Location = new System.Drawing.Point(678, 315);
            this.cambiarVelocidadesButton.Margin = new System.Windows.Forms.Padding(2);
            this.cambiarVelocidadesButton.Name = "cambiarVelocidadesButton";
            this.cambiarVelocidadesButton.Size = new System.Drawing.Size(77, 40);
            this.cambiarVelocidadesButton.TabIndex = 9;
            this.cambiarVelocidadesButton.Text = "Cambiar velocidades";
            this.cambiarVelocidadesButton.UseVisualStyleBackColor = true;
            this.cambiarVelocidadesButton.Click += new System.EventHandler(this.cambiarVelocidadesButton_Click);
            // 
            // atrasButton
            // 
            this.atrasButton.Location = new System.Drawing.Point(32, 40);
            this.atrasButton.Name = "atrasButton";
            this.atrasButton.Size = new System.Drawing.Size(75, 23);
            this.atrasButton.TabIndex = 10;
            this.atrasButton.Text = "Atras";
            this.atrasButton.UseVisualStyleBackColor = true;
            this.atrasButton.Click += new System.EventHandler(this.atrasButton_Click);
            // 
            // FormEspacioAereo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(796, 548);
            this.Controls.Add(this.atrasButton);
            this.Controls.Add(this.cambiarVelocidadesButton);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.conflictosButton);
            this.Controls.Add(this.DatosVuelosButton);
            this.Controls.Add(this.moverButton);
            this.Controls.Add(this.startAutoButton);
            this.Controls.Add(this.stopAutoButton);
            this.Controls.Add(this.eje_y);
            this.Controls.Add(this.eje_x);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(300, 300);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormEspacioAereo";
            this.Text = "EspacioAereo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormEspacioAereo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avion1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox avion1;
        private System.Windows.Forms.Label eje_x;
        private System.Windows.Forms.Label eje_y;
        private System.Windows.Forms.Button moverButton;
        private System.Windows.Forms.Timer autoTimer;
        private System.Windows.Forms.Button startAutoButton;
        private System.Windows.Forms.Button stopAutoButton;
        private System.Windows.Forms.Button DatosVuelosButton;
        private System.Windows.Forms.Button conflictosButton;
        private System.Windows.Forms.Button buttonReiniciar;
        private System.Windows.Forms.Button cambiarVelocidadesButton;
        private System.Windows.Forms.Button atrasButton;
    }

}
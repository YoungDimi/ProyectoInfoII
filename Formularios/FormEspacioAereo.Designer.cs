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
            this.avion2 = new System.Windows.Forms.PictureBox();
            this.avion1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eje_x = new System.Windows.Forms.Label();
            this.eje_y = new System.Windows.Forms.Label();
            this.moverButton = new System.Windows.Forms.Button();
            this.DatosVuelosButton = new System.Windows.Forms.Button();
            this.conflictosButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avion2)).BeginInit();
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
            this.startAutoButton.Location = new System.Drawing.Point(1370, 351);
            this.startAutoButton.Name = "startAutoButton";
            this.startAutoButton.Size = new System.Drawing.Size(120, 41);
            this.startAutoButton.TabIndex = 4;
            this.startAutoButton.Text = "Iniciar Auto";
            this.startAutoButton.UseVisualStyleBackColor = true;
            this.startAutoButton.Click += new System.EventHandler(this.StartAutoButton_Click);
            // 
            // stopAutoButton
            // 
            this.stopAutoButton.Enabled = false;
            this.stopAutoButton.Location = new System.Drawing.Point(1370, 398);
            this.stopAutoButton.Name = "stopAutoButton";
            this.stopAutoButton.Size = new System.Drawing.Size(120, 41);
            this.stopAutoButton.TabIndex = 5;
            this.stopAutoButton.Text = "Detener Auto";
            this.stopAutoButton.UseVisualStyleBackColor = true;
            this.stopAutoButton.Click += new System.EventHandler(this.StopAutoButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.avion2);
            this.panel1.Controls.Add(this.avion1);
            this.panel1.Location = new System.Drawing.Point(150, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 800);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // avion2
            // 
            this.avion2.BackColor = System.Drawing.Color.Transparent;
            this.avion2.Image = global::Formularios.Properties.Resources.avion_negro;
            this.avion2.Location = new System.Drawing.Point(638, 286);
            this.avion2.Name = "avion2";
            this.avion2.Size = new System.Drawing.Size(30, 30);
            this.avion2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avion2.TabIndex = 1;
            this.avion2.TabStop = false;
            this.avion2.Click += new System.EventHandler(this.avion2_Click);
            // 
            // avion1
            // 
            this.avion1.BackColor = System.Drawing.Color.Transparent;
            this.avion1.Image = ((System.Drawing.Image)(resources.GetObject("avion1.Image")));
            this.avion1.Location = new System.Drawing.Point(753, 231);
            this.avion1.Name = "avion1";
            this.avion1.Size = new System.Drawing.Size(30, 30);
            this.avion1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avion1.TabIndex = 0;
            this.avion1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(583, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESPACIO AEREO.";
            // 
            // eje_x
            // 
            this.eje_x.AutoSize = true;
            this.eje_x.Location = new System.Drawing.Point(120, 555);
            this.eje_x.Name = "eje_x";
            this.eje_x.Size = new System.Drawing.Size(24, 25);
            this.eje_x.TabIndex = 1;
            this.eje_x.Text = "0";
            // 
            // eje_y
            // 
            this.eje_y.AutoSize = true;
            this.eje_y.Location = new System.Drawing.Point(681, 964);
            this.eje_y.Name = "eje_y";
            this.eje_y.Size = new System.Drawing.Size(24, 25);
            this.eje_y.TabIndex = 2;
            this.eje_y.Text = "0";
            // 
            // moverButton
            // 
            this.moverButton.Location = new System.Drawing.Point(1356, 239);
            this.moverButton.Name = "moverButton";
            this.moverButton.Size = new System.Drawing.Size(154, 92);
            this.moverButton.TabIndex = 3;
            this.moverButton.Text = "Mover un ciclo";
            this.moverButton.UseVisualStyleBackColor = true;
            this.moverButton.Click += new System.EventHandler(this.moverButton_Click);
            // 
            // DatosVuelosButton
            // 
            this.DatosVuelosButton.Location = new System.Drawing.Point(1356, 676);
            this.DatosVuelosButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DatosVuelosButton.Name = "DatosVuelosButton";
            this.DatosVuelosButton.Size = new System.Drawing.Size(154, 91);
            this.DatosVuelosButton.TabIndex = 6;
            this.DatosVuelosButton.Text = "Ver datos de los vuelos";
            this.DatosVuelosButton.UseVisualStyleBackColor = true;
            this.DatosVuelosButton.Click += new System.EventHandler(this.DatosVuelosButton_Click);
            // 
            // conflictosButton
            // 
            this.conflictosButton.Location = new System.Drawing.Point(1356, 787);
            this.conflictosButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.conflictosButton.Name = "conflictosButton";
            this.conflictosButton.Size = new System.Drawing.Size(154, 109);
            this.conflictosButton.TabIndex = 7;
            this.conflictosButton.Text = "Comprobar conflictos futuros";
            this.conflictosButton.UseVisualStyleBackColor = true;
            this.conflictosButton.Click += new System.EventHandler(this.conflictosButton_Click);
            // 
            // FormEspacioAereo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1592, 1055);
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
            this.Name = "FormEspacioAereo";
            this.Text = "EspacioAereo";
            this.Load += new System.EventHandler(this.FormEspacioAereo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avion1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox avion2;
        private System.Windows.Forms.PictureBox avion1;
        private System.Windows.Forms.Label eje_x;
        private System.Windows.Forms.Label eje_y;
        private System.Windows.Forms.Button moverButton;
        private System.Windows.Forms.Timer autoTimer;
        private System.Windows.Forms.Button startAutoButton;
        private System.Windows.Forms.Button stopAutoButton;
        private System.Windows.Forms.Button DatosVuelosButton;
        private System.Windows.Forms.Button conflictosButton;
    }

}
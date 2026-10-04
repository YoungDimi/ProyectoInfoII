namespace Formularios
{
    partial class FormAddConfig
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
            this.securityDistance = new System.Windows.Forms.TextBox();
            this.cycleTime = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distancia de seguridad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tiempo de ciclo (seg):";
            // 
            // securityDistance
            // 
            this.securityDistance.Location = new System.Drawing.Point(185, 40);
            this.securityDistance.Name = "securityDistance";
            this.securityDistance.Size = new System.Drawing.Size(100, 22);
            this.securityDistance.TabIndex = 2;
            // 
            // cycleTime
            // 
            this.cycleTime.Location = new System.Drawing.Point(185, 98);
            this.cycleTime.Name = "cycleTime";
            this.cycleTime.Size = new System.Drawing.Size(100, 22);
            this.cycleTime.TabIndex = 3;
            this.cycleTime.TextChanged += new System.EventHandler(this.cycleTime_TextChanged);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(115, 149);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(96, 38);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // FormAddConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 220);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.cycleTime);
            this.Controls.Add(this.securityDistance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddConfig";
            this.Text = "Añadir configuración";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox securityDistance;
        private System.Windows.Forms.TextBox cycleTime;
        private System.Windows.Forms.Button acceptButton;
    }
}
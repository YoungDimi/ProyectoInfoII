namespace Formularios
{
    partial class FormAddFlightPlans
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
            this.addFlightPlansButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fp1_id = new System.Windows.Forms.TextBox();
            this.fp1_initialPos = new System.Windows.Forms.TextBox();
            this.fp1_finalPos = new System.Windows.Forms.TextBox();
            this.fp1_Velocity = new System.Windows.Forms.TextBox();
            this.fp2_Velocity = new System.Windows.Forms.TextBox();
            this.fp2_finalPos = new System.Windows.Forms.TextBox();
            this.fp2_initialPos = new System.Windows.Forms.TextBox();
            this.fp2_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(66, 173);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1068, 161);
            this.label1.TabIndex = 2;
            this.label1.Text = "Flight Plan 1";
            // 
            // addFlightPlansButton
            // 
            this.addFlightPlansButton.Location = new System.Drawing.Point(494, 580);
            this.addFlightPlansButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addFlightPlansButton.Name = "addFlightPlansButton";
            this.addFlightPlansButton.Size = new System.Drawing.Size(183, 64);
            this.addFlightPlansButton.TabIndex = 4;
            this.addFlightPlansButton.Text = "Añadir";
            this.addFlightPlansButton.UseVisualStyleBackColor = true;
            this.addFlightPlansButton.Click += new System.EventHandler(this.addFlightPlansButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 233);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Posición inicial:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(640, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Posición final:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(912, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Velocidad:";
            // 
            // fp1_id
            // 
            this.fp1_id.Location = new System.Drawing.Point(140, 262);
            this.fp1_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fp1_id.Name = "fp1_id";
            this.fp1_id.Size = new System.Drawing.Size(109, 31);
            this.fp1_id.TabIndex = 13;
            // 
            // fp1_initialPos
            // 
            this.fp1_initialPos.Location = new System.Drawing.Point(352, 262);
            this.fp1_initialPos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fp1_initialPos.Name = "fp1_initialPos";
            this.fp1_initialPos.Size = new System.Drawing.Size(145, 31);
            this.fp1_initialPos.TabIndex = 14;
            // 
            // fp1_finalPos
            // 
            this.fp1_finalPos.Location = new System.Drawing.Point(636, 262);
            this.fp1_finalPos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fp1_finalPos.Name = "fp1_finalPos";
            this.fp1_finalPos.Size = new System.Drawing.Size(145, 31);
            this.fp1_finalPos.TabIndex = 15;
            // 
            // fp1_Velocity
            // 
            this.fp1_Velocity.Location = new System.Drawing.Point(909, 262);
            this.fp1_Velocity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fp1_Velocity.Name = "fp1_Velocity";
            this.fp1_Velocity.Size = new System.Drawing.Size(110, 31);
            this.fp1_Velocity.TabIndex = 16;
            // 
            // fp2_Velocity
            // 
            this.fp2_Velocity.Location = new System.Drawing.Point(909, 469);
            this.fp2_Velocity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fp2_Velocity.Name = "fp2_Velocity";
            this.fp2_Velocity.Size = new System.Drawing.Size(110, 31);
            this.fp2_Velocity.TabIndex = 25;
            // 
            // fp2_finalPos
            // 
            this.fp2_finalPos.Location = new System.Drawing.Point(636, 469);
            this.fp2_finalPos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fp2_finalPos.Name = "fp2_finalPos";
            this.fp2_finalPos.Size = new System.Drawing.Size(145, 31);
            this.fp2_finalPos.TabIndex = 24;
            // 
            // fp2_initialPos
            // 
            this.fp2_initialPos.Location = new System.Drawing.Point(352, 469);
            this.fp2_initialPos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fp2_initialPos.Name = "fp2_initialPos";
            this.fp2_initialPos.Size = new System.Drawing.Size(145, 31);
            this.fp2_initialPos.TabIndex = 23;
            // 
            // fp2_id
            // 
            this.fp2_id.Location = new System.Drawing.Point(140, 469);
            this.fp2_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fp2_id.Name = "fp2_id";
            this.fp2_id.Size = new System.Drawing.Size(109, 31);
            this.fp2_id.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(912, 438);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Velocidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 438);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Posición final:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 438);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Posición inicial:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 439);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "ID:";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.Location = new System.Drawing.Point(66, 380);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1068, 161);
            this.label10.TabIndex = 17;
            this.label10.Text = "Flight Plan 2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(75, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(953, 25);
            this.label11.TabIndex = 26;
            this.label11.Text = "Añada los datos de dos planes de vuelos en esta ventana utilizando el siguiente f" +
    "ormato:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(90, 83);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1031, 25);
            this.label12.TabIndex = 27;
            this.label12.Text = "- ID: texto   Posición inicial: x_inicial y_inicial   Posición final: x_final y_f" +
    "inal   Velocidad: número";
            // 
            // FormAddFlightPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 678);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.fp2_Velocity);
            this.Controls.Add(this.fp2_finalPos);
            this.Controls.Add(this.fp2_initialPos);
            this.Controls.Add(this.fp2_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.fp1_Velocity);
            this.Controls.Add(this.fp1_finalPos);
            this.Controls.Add(this.fp1_initialPos);
            this.Controls.Add(this.fp1_id);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addFlightPlansButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAddFlightPlans";
            this.Text = "Añadir planes de vuelo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addFlightPlansButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fp1_id;
        private System.Windows.Forms.TextBox fp1_initialPos;
        private System.Windows.Forms.TextBox fp1_finalPos;
        private System.Windows.Forms.TextBox fp1_Velocity;
        private System.Windows.Forms.TextBox fp2_Velocity;
        private System.Windows.Forms.TextBox fp2_finalPos;
        private System.Windows.Forms.TextBox fp2_initialPos;
        private System.Windows.Forms.TextBox fp2_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}
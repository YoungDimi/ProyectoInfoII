using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormAddConfig : Form
    {
        double securityDistanceVal;
        int cycleTimeVal;

        public FormAddConfig()
        {
            InitializeComponent();
        }
        public double GetSecurityDistance()
        {
            return securityDistanceVal;
        }
        public void SetSecurityDistance(double value)
        {
            // asignar el valor de la distancia de seguridad y actualizar el TextBox correspondiente 
             
            securityDistanceVal = value;
            securityDistance.Text = value.ToString();
        }
        public int GetCycleTime()
        {
            return cycleTimeVal;
        }
        public void SetCycleTime(int value)
        {
            // método para asignar el valor del tiempo de ciclo y actualizar el TextBox correspondiente 
             
            cycleTimeVal = value;
            cycleTime.Text = value.ToString();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                double securityDistanceValue = Convert.ToDouble(securityDistance.Text);
                if (securityDistanceValue < 0)
                {
                    MessageBox.Show("La distancia de seguridad debe ser un número positivo.");
                    return;
                }

                int cycleTimeValue = Convert.ToInt32(cycleTime.Text);
                if (cycleTimeValue < 0)
                {
                    MessageBox.Show("El tiempo de ciclo debe ser un número positivo.");
                    return;
                }

                securityDistanceVal = securityDistanceValue;
                cycleTimeVal = cycleTimeValue;
                this.Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos.");
                return;
            }
        }
    }
}

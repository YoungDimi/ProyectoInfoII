using System;
using System.Windows.Forms;

namespace Formularios
{
    // ventana para poner la distancia de seguridad y el tiempo de ciclo
    public partial class FormAddConfig : Form
    {
        double securityDistanceVal;
        int cycleTimeVal;

        public FormAddConfig()
        {
            InitializeComponent();
        }

        // devuelve la distancia de seguridad
        public double GetSecurityDistance()
        {
            return securityDistanceVal;
        }

        // recibe la distancia de seguridad actual y la escribe en su casilla
        public void SetSecurityDistance(double value)
        {
            securityDistanceVal = value;
            securityDistance.Text = value.ToString();
        }

        // devuelve el tiempo de ciclo
        public int GetCycleTime()
        {
            return cycleTimeVal;
        }

        // recibe el tiempo de ciclo actual y lo escribe en su casilla
        public void SetCycleTime(int value)
        {
            cycleTimeVal = value;
            cycleTime.Text = value.ToString();
        }

        // comprueba los dos valores y si estan bien los guarda y cierra
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

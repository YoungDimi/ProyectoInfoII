using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Formularios
{
    public partial class FormAddFlightPlans : Form
    {
        FlightPlan flightplan1;
        FlightPlan flightplan2;
        public FormAddFlightPlans()
        {
            InitializeComponent();
        }

        public FlightPlan GetFlightPlan1()
        {
            return flightplan1;
        }
        public FlightPlan GetFlightPlan2()
        {
            return flightplan2;
        }

        private void addFlightPlansButton_Click(object sender, EventArgs e)
        {
            try
            {
                /* Convertimos los valores de los TextBox a los tipos de datos correspondientes 
                 para cada FlightPlan. */

                // FlightPlan 1
                string id1 = fp1_id.Text;
                string[] initialPosition1 = fp1_initialPos.Text.Split(' ');
                if (initialPosition1.Length != 2)
                {
                    MessageBox.Show("La posición inicial del FlightPlan 1 debe tener dos coordenadas separadas por un espacio.");
                    return;
                }
                double cpx1 = Convert.ToDouble(initialPosition1[0]);
                double cpy1 = Convert.ToDouble(initialPosition1[1]);

                string[] finalPosition1 = fp1_finalPos.Text.Split(' ');
                if (finalPosition1.Length != 2)
                {
                    MessageBox.Show("La posición final del FlightPlan 1 debe tener dos coordenadas separadas por un espacio.");
                    return;
                }
                double fpx1 = Convert.ToDouble(finalPosition1[0]);
                double fpy1 = Convert.ToDouble(finalPosition1[1]);

                double velocidad1 = Convert.ToDouble(fp1_Velocity.Text);

                // FlightPlan 2
                string id2 = fp2_id.Text;
                string[] initialPosition2 = fp2_initialPos.Text.Split(' ');
                if (initialPosition2.Length != 2)
                {
                    MessageBox.Show("La posición inicial del FlightPlan 2 debe tener dos coordenadas separadas por un espacio.");
                    return;
                }
                double cpx2 = Convert.ToDouble(initialPosition2[0]);
                double cpy2 = Convert.ToDouble(initialPosition2[1]);

                string[] finalPosition2 = fp2_finalPos.Text.Split(' ');
                if (finalPosition2.Length != 2)
                {
                    MessageBox.Show("La posición final del FlightPlan 2 debe tener dos coordenadas separadas por un espacio.");
                    return;
                }
                double fpx2 = Convert.ToDouble(finalPosition2[0]);
                double fpy2 = Convert.ToDouble(finalPosition2[1]);

                double velocidad2 = Convert.ToDouble(fp2_Velocity.Text);


                // Inicializamos los FlightPlans con los valores obtenidos de los TextBox.
                flightplan1 = new FlightPlan(id1, cpx1, cpy1, fpx1, fpy1, velocidad1);
                flightplan2 = new FlightPlan(id2, cpx2, cpy2, fpx2, fpy2, velocidad2);

                // Cerramos el formulario emergente.
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, asegúrese de que todos los campos estén llenos y que los valores numéricos sean válidos.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAddFlightPlans_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}

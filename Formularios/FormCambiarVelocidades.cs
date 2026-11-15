using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormCambiarVelocidades : Form
    {
        FlightPlanList lista; // todos los vuelos de la simulación
        bool cambiado = false;  // pasa a true si el usuario aplica velocidades nuevas
        public FormCambiarVelocidades()
        {
            InitializeComponent();
        }
        // Establece la lista de vuelos proveniente del FormEspacioAereo
        public void SetFlightPlans(FlightPlanList l)
        {
            lista = l;
        }
        // Devuelve true si el usuario ha aplicado velocidades nuevas
        public bool GetCambiado()
        {
            return cambiado;
        }
        // Rellena la tabla con una fila por vuelo: su nombre y velocidad actual
        // El usuario puede cambiar la velocidad de cada vuelo, el nombre no
        private void FormCambiarVelocidades_Load(object sender, EventArgs e)
        {
            tablaVelocidades.ColumnCount = 2;
            tablaVelocidades.RowCount = lista.GetNumber();

            tablaVelocidades.Columns[0].Name = "Vuelo";
            tablaVelocidades.Columns[1].Name = "Velocidad";

            // el nombre del vuelo no se puede cambiar, la velocidad sí
            tablaVelocidades.Columns[0].ReadOnly = true;

            for (int i = 0; i < lista.GetNumber(); i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                tablaVelocidades.Rows[i].Cells[0].Value = f.GetId();
                tablaVelocidades.Rows[i].Cells[1].Value = f.GetVelocidad();
            }

        }
        // Lee las velocidades nuevas de la tabla y las aplica a todos los vuelos
        // Si alguna no es válida, no cambia nada y avisa al usuario
        private void aplicarButton_Click(object sender, EventArgs e)
        {
            try
            {
                // leemos todas las velocidades antes de cambiar ninguna
                double[] nuevas = new double[lista.GetNumber()];
                for (int i = 0; i < nuevas.Length; i++)
                {
                    nuevas[i] = Convert.ToDouble(tablaVelocidades.Rows[i].Cells[1].Value);
                    if (nuevas[i] <= 0)
                    {
                        MessageBox.Show("Todas las velocidades tienen que ser mayores que 0.");
                        return;
                    }
                }
                // si todas son válidas, las aplicamos
                for (int i = 0; i < nuevas.Length; i++)
                {
                    lista.GetFlightPlan(i).SetVelocidad(nuevas[i]);
                }

                cambiado = true;
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Escribe un número válido en las velocidades.");
            }
        }
    }
}
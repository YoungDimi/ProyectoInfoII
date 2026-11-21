using FlightLib;
using System;
using System.Windows.Forms;

namespace Formularios
{
    // ventana para cambiar la velocidad de los vuelos durante la simulacion
    public partial class FormCambiarVelocidades : Form
    {
        FlightPlanList lista;
        bool cambiado = false; // true si se han aplicado velocidades nuevas

        public FormCambiarVelocidades()
        {
            InitializeComponent();
        }

        // recibe la lista de vuelos del espacio aereo
        public void SetFlightPlans(FlightPlanList l)
        {
            lista = l;
        }

        // devuelve true si se han cambiado las velocidades
        public bool GetCambiado()
        {
            return cambiado;
        }

        // rellena la tabla con cada vuelo y su velocidad
        private void FormCambiarVelocidades_Load(object sender, EventArgs e)
        {
            tablaVelocidades.ColumnCount = 2;
            tablaVelocidades.RowCount = lista.GetNumber();

            tablaVelocidades.Columns[0].Name = "Vuelo";
            tablaVelocidades.Columns[1].Name = "Velocidad";

            // solo se puede cambiar la velocidad, el nombre no
            tablaVelocidades.Columns[0].ReadOnly = true;

            for (int i = 0; i < lista.GetNumber(); i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                tablaVelocidades.Rows[i].Cells[0].Value = f.GetId();
                tablaVelocidades.Rows[i].Cells[1].Value = f.GetVelocidad();
            }

        }

        // lee las velocidades nuevas y se las pone a los vuelos
        // si alguna esta mal avisa y no cambia ninguna
        private void aplicarButton_Click(object sender, EventArgs e)
        {
            try
            {
                // primero las leemos y comprobamos todas
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
                // y luego las aplicamos
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

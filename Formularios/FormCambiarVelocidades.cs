using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormCambiarVelocidades : Form
    {
        FlightPlan fp1;
        FlightPlan fp2;
        bool cambiado = false;  // pasa a true si el usuario aplica velocidades nuevas
        public FormCambiarVelocidades()
        {
            InitializeComponent();
        }
        public void SetFlightPlans(FlightPlan p1, FlightPlan p2)
        {
            fp1 = p1;
            fp2 = p2;
        }

        public bool GetCambiado()
        {
            return cambiado;
        }

        private void FormCambiarVelocidades_Load(object sender, EventArgs e)
        {
            // tabla con una fila por vuelo: su nombre y su velocidad actual
            tablaVelocidades.ColumnCount = 2;
            tablaVelocidades.RowCount = 2;

            tablaVelocidades.Columns[0].Name = "Vuelo";
            tablaVelocidades.Columns[1].Name = "Velocidad";

            // el nombre del vuelo no se puede cambiar, solo la velocidad
            tablaVelocidades.Columns[0].ReadOnly = true;

            tablaVelocidades.Rows[0].Cells[0].Value = fp1.GetId();
            tablaVelocidades.Rows[0].Cells[1].Value = fp1.GetVelocidad();

            tablaVelocidades.Rows[1].Cells[0].Value = fp2.GetId();
            tablaVelocidades.Rows[1].Cells[1].Value = fp2.GetVelocidad();

        }

        private void aplicarButton_Click(object sender, EventArgs e)
        {
            try
            {
                // leemos las velocidades nuevas de la tabla (fila 0 = vuelo 1, fila 1 = vuelo 2)
                double v1 = Convert.ToDouble(tablaVelocidades.Rows[0].Cells[1].Value);
                double v2 = Convert.ToDouble(tablaVelocidades.Rows[1].Cells[1].Value);

                if (v1 <= 0 || v2 <= 0)
                {
                    MessageBox.Show("Las velocidades tienen que ser mayores que 0.");
                    return;
                }

                // si todo está bien, cambiamos las velocidades de los vuelos
                fp1.SetVelocidad(v1);
                fp2.SetVelocidad(v2);

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

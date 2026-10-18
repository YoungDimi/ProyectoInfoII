using FlightLib;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormDatosVuelos : Form
    {
        FlightPlan fp1;
        FlightPlan fp2;

        public FormDatosVuelos()
        {
            InitializeComponent();
        }

        public void SetFlightPlans(FlightPlan p1, FlightPlan p2)
        {
            fp1 = p1;
            fp2 = p2;
        }

        private void FormDatosVuelos_Load(object sender, EventArgs e)
        {
            // TABLA DE DATOS DE VUELOS

            // configuración de la tabla de datos de vuelo
            tablaDatos.ColumnCount = 4;
            tablaDatos.RowCount = 2; // dos filas para dos vuelos 

            //encabezados de columna
            tablaDatos.Columns[0].Name = "Vuelo";
            tablaDatos.Columns[1].Name = "Posición actual (X, Y)";
            tablaDatos.Columns[2].Name = "Posición final (X, Y)";
            tablaDatos.Columns[3].Name = "Velocidad";


            // datos del primer vuelo
            tablaDatos.Rows[0].Cells[0].Value = fp1.GetId();
            tablaDatos.Rows[0].Cells[1].Value = $"({Math.Round(fp1.GetCurrentPosition().GetX(), 3)}, {Math.Round(fp1.GetCurrentPosition().GetY(), 3)})";
            tablaDatos.Rows[0].Cells[2].Value = $"({Math.Round(fp1.GetFinalPosition().GetX(), 3)}, {Math.Round(fp1.GetFinalPosition().GetY(), 3)})";
            tablaDatos.Rows[0].Cells[3].Value = fp1.GetVelocidad();

            // datos del segundo vuelo 
            tablaDatos.Rows[1].Cells[0].Value = fp2.GetId();
            tablaDatos.Rows[1].Cells[1].Value = $"({Math.Round(fp2.GetCurrentPosition().GetX(), 3)}, {Math.Round(fp2.GetCurrentPosition().GetY(), 3)})";
            tablaDatos.Rows[1].Cells[2].Value = $"({Math.Round(fp2.GetFinalPosition().GetX(), 3)}, {Math.Round(fp2.GetFinalPosition().GetY(), 3 )})";
            tablaDatos.Rows[1].Cells[3].Value = fp2.GetVelocidad();
        }

        private void tablaDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // al hacer click en una celda,se abre un nuevo form con la distancia entre ese vuelo  y el otro

            // obtenemos cual es el vuelo clickado y cual es el otro 
            int index = e.RowIndex;
            FlightPlan clickedFlightPlan;
            FlightPlan otherFlightPlan;
            if (index == 0)
            {
                clickedFlightPlan = fp1;
                otherFlightPlan = fp2;
            }
            else
            {
                clickedFlightPlan = fp2;
                otherFlightPlan = fp1;
            }

            // creamos un nuevo form para mostrar la distancia entre los dos vuelos
            FormDistanciasVuelos formDistancias = new FormDistanciasVuelos();
            formDistancias.SetFlightPlans(clickedFlightPlan, otherFlightPlan);
            formDistancias.ShowDialog();
        }
    }
}

using FlightLib;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormDatosVuelos : Form
    {
        FlightPlanList lista; // lista de planes de vuelo

        public FormDatosVuelos()
        {
            InitializeComponent();
        }

        // Establece la lista de planes de vuelo proveniente del FormEspacioAereo
        public void SetFlightPlans(FlightPlanList l)
        {
            lista = l;
        }

        // Rellena la tabla con una fila por cada vuelo de la lista
        private void FormDatosVuelos_Load(object sender, EventArgs e)
        {
            // configuración de la tabla de datos de vuelo
            tablaDatos.ColumnCount = 5;
            tablaDatos.RowCount = lista.GetNumber();

            //encabezados de columna
            tablaDatos.Columns[0].Name = "Vuelo";
            tablaDatos.Columns[1].Name = "Compañía";
            tablaDatos.Columns[2].Name = "Posición actual (X, Y)";
            tablaDatos.Columns[3].Name = "Posición final (X, Y)";
            tablaDatos.Columns[4].Name = "Velocidad";


            // rellenamos la tabla con los datos de cada vuelo
            for (int i = 0; i < lista.GetNumber(); i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                tablaDatos.Rows[i].Cells[0].Value = f.GetId();
                tablaDatos.Rows[i].Cells[1].Value = f.GetCompañia();
                tablaDatos.Rows[i].Cells[2].Value = $"({Math.Round(f.GetCurrentPosition().GetX(), 3)}, {Math.Round(f.GetCurrentPosition().GetY(), 3)})";
                tablaDatos.Rows[i].Cells[3].Value = $"({Math.Round(f.GetFinalPosition().GetX(), 3)}, {Math.Round(f.GetFinalPosition().GetY(), 3)})";
                tablaDatos.Rows[i].Cells[4].Value = f.GetVelocidad();
            }
        }

        // Al hacer click en una fila, abrimos un nuevo form con las distancias entre ese vuelo y los demás vuelos de la lista
        private void tablaDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            // index es -1 si se ha hecho clic en la cabecera
            if (index < 0)
                return;

            FlightPlan clickedFlightPlan = lista.GetFlightPlan(index);

            // Abrimos el form de distancias, pasándole el vuelo clicado y la lista de vuelos
            FormDistanciasVuelos formDistancias = new FormDistanciasVuelos();
            formDistancias.SetFlightPlans(clickedFlightPlan, lista);
            formDistancias.ShowDialog();
        }
    }
}

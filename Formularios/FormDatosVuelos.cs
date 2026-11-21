using FlightLib;
using System;
using System.Windows.Forms;

namespace Formularios
{
    // tabla con los datos de todos los vuelos
    public partial class FormDatosVuelos : Form
    {
        FlightPlanList lista;

        public FormDatosVuelos()
        {
            InitializeComponent();
        }

        // recibe la lista de vuelos del espacio aereo
        public void SetFlightPlans(FlightPlanList l)
        {
            lista = l;
        }

        // rellena la tabla, una fila por vuelo
        private void FormDatosVuelos_Load(object sender, EventArgs e)
        {
            tablaDatos.ColumnCount = 5;
            tablaDatos.RowCount = lista.GetNumber();

            tablaDatos.Columns[0].Name = "Vuelo";
            tablaDatos.Columns[1].Name = "Compañía";
            tablaDatos.Columns[2].Name = "Posición actual (X, Y)";
            tablaDatos.Columns[3].Name = "Posición final (X, Y)";
            tablaDatos.Columns[4].Name = "Velocidad";

            for (int i = 0; i < lista.GetNumber(); i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                tablaDatos.Rows[i].Cells[0].Value = f.GetId();
                tablaDatos.Rows[i].Cells[1].Value = f.GetCompañia();
                tablaDatos.Rows[i].Cells[2].Value = "(" + Math.Round(f.GetCurrentPosition().GetX(), 3) + ", " + Math.Round(f.GetCurrentPosition().GetY(), 3) + ")";
                tablaDatos.Rows[i].Cells[3].Value = "(" + Math.Round(f.GetFinalPosition().GetX(), 3) + ", " + Math.Round(f.GetFinalPosition().GetY(), 3) + ")";
                tablaDatos.Rows[i].Cells[4].Value = f.GetVelocidad();
            }
        }

        // al clicar una fila se abre otra ventana con la distancia de ese vuelo a los demas
        private void tablaDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            // -1 si se ha clicado la cabecera
            if (index < 0)
                return;

            FlightPlan clickedFlightPlan = lista.GetFlightPlan(index);

            FormDistanciasVuelos formDistancias = new FormDistanciasVuelos();
            formDistancias.SetFlightPlans(clickedFlightPlan, lista);
            formDistancias.ShowDialog();
        }
    }
}

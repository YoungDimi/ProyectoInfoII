using FlightLib;
using System;
using System.Windows.Forms;

namespace Formularios
{
    // tabla con la distancia de un vuelo a todos los demas
    public partial class FormDistanciasVuelos : Form
    {
        FlightPlan clickedFlightPlan; // el vuelo que se ha clicado
        FlightPlanList lista;

        public FormDistanciasVuelos()
        {
            InitializeComponent();
        }

        // recibe el vuelo clicado y la lista de vuelos
        public void SetFlightPlans(FlightPlan clicked, FlightPlanList l)
        {
            clickedFlightPlan = clicked;
            lista = l;
        }

        // rellena la tabla con la distancia a cada uno de los otros vuelos
        private void FormDistanciasVuelos_Load(object sender, EventArgs e)
        {
            IDsVuelosLabel.Text = "Distancias desde " + clickedFlightPlan.GetId();

            tablaDistancias.ColumnCount = 2;
            tablaDistancias.Columns[0].Name = "Vuelo";
            tablaDistancias.Columns[1].Name = "Distancia";

            // una fila por cada vuelo menos el clicado
            tablaDistancias.RowCount = lista.GetNumber() - 1;

            int fila = 0;
            for (int i = 0; i < lista.GetNumber(); i++)
            {
                FlightPlan otro = lista.GetFlightPlan(i);
                if (otro != clickedFlightPlan)
                {
                    tablaDistancias.Rows[fila].Cells[0].Value = otro.GetId();
                    tablaDistancias.Rows[fila].Cells[1].Value = Math.Round(clickedFlightPlan.Distance(otro), 3);
                    fila++;
                }
            }

            tablaDistancias.ReadOnly = true;

        }

    }
}

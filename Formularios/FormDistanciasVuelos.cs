using FlightLib;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormDistanciasVuelos : Form
    {
        FlightPlan clickedFlightPlan; // vuelo sobre el que se ha hecho clic en FormDatosVuelos
        FlightPlanList lista; // lista de planes de vuelo
        public FormDistanciasVuelos()
        {
            InitializeComponent();
        }

        public void SetFlightPlans(FlightPlan clicked, FlightPlanList l)
        {
            clickedFlightPlan = clicked;
            lista = l;
            // asi guardamos la informacion que recibimos del FormDatosVuelos
        }

        // Muestra en una tabla la distancia del vuelo clicado a cada uno de los demás
        private void FormDistanciasVuelos_Load(object sender, EventArgs e)
        {
            IDsVuelosLabel.Text = "Distancias desde " + clickedFlightPlan.GetId();

            // columnas: vuelo y distancia
            tablaDistancias.ColumnCount = 2;
            tablaDistancias.Columns[0].Name = "Vuelo";
            tablaDistancias.Columns[1].Name = "Distancia";

            // solo las filas de los vuelos distintos al vuelo clicado
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

            tablaDistancias.ReadOnly = true; // no se pueden editar las distancias

        }

    }
}

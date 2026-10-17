using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormDistanciasVuelos : Form
    {
        FlightPlan clickedFlightPlan;
        FlightPlan otherFlightPlan;
        public FormDistanciasVuelos()
        {
            InitializeComponent();
        }

        public void SetFlightPlans(FlightPlan clicked, FlightPlan other)
        {
            clickedFlightPlan = clicked;
            otherFlightPlan = other;
            // asi guardamos la informacion que recibimos del FormDatosVuelos
        }
        private void FormDistanciasVuelos_Load(object sender, EventArgs e)
        {
            // Mostramos los IDs de los vuelos en el label correspondiente
            IDsVuelosLabel.Text = $"{clickedFlightPlan.GetId()} ⟶ {otherFlightPlan.GetId()}";

            // Calculamos y mostramos la distancia entre los dos vuelos
            double distancia = clickedFlightPlan.Distance(otherFlightPlan);
            DistanciaLabel.Text = $"Distancia: {Math.Round(distancia, 3)}";

        }
    }
}

using FlightLib;
using System;
using System.Windows.Forms;

namespace Formularios
{
    // ventana con los datos del avion en el que se ha hecho clic
    public partial class FlightInfo : Form
    {
        FlightPlan myflight;

        // recibe el vuelo que hay que mostrar
        public void SetFlightPlan(FlightPlan f)
        {
           this.myflight = f;
        }

        public FlightInfo()
        {
            InitializeComponent();
        }

        // pone en las casillas la posicion, la velocidad y la compañia del vuelo
        private void FlightInfo_Load(object sender, EventArgs e)
        {
            Xbox.Text = Convert.ToString(myflight.GetCurrentPosition().GetX());
            Ybox.Text = Convert.ToString(myflight.GetCurrentPosition().GetY());
            Speedbox.Text = Convert.ToString(myflight.GetVelocidad());
            compañiaBox.Text = myflight.GetCompañia();
        }

        // cierra la ventana
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}

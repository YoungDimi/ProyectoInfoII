using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Formularios
{
    public partial class FormEspacioAereo : Form
    {
        FlightPlan flightplan1;
        FlightPlan flightplan2;
        double securityDistance;
        int cycleTime;
        public FormEspacioAereo()
        {
            InitializeComponent();
        }

        public void SetFlightPlans(FlightPlan p1, FlightPlan p2)
        {
            flightplan1 = p1;
            flightplan2 = p2;
            // asi guardamos la informacion que recibimos de principal
        }

        public void SetConfig(double sd , int ct )
        {
            securityDistance = sd;
            cycleTime = ct;
            // asi guardamos la informacion que recibimos de principal
        }

        private void panel1_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            int centroX = panel1.Width / 2;
            int centroY = panel1.Height / 2;

            e.Graphics.DrawLine(Pens.Black, 0, centroY, panel1.Width, centroY);   // eje X (horizontal)
            e.Graphics.DrawLine(Pens.Black, centroX, 0, centroX, panel1.Height);  // eje Y (vertical)
        }

        private void ColocarAviones()
        {
            // AVION 1

            // esto es lo que se ejecuta JUSTO al abrirse el form Espacio Aereo
            double x1 = flightplan1.GetCurrentPosition().GetX();
            double y1 = flightplan1.GetCurrentPosition().GetY();
            // leemos la posición actual del avión 1 (esto se puede hacer porque principal
            // ya nos ha pasado los vuelos con SetFlighplans)
            double pixelX1 = panel1.Width / 2 + x1; // porque x=0 es pixel 550 de nuestro panel
            double pixelY1 = panel1.Height / 2 - y1; // poruqe y=0 es pixel 400 de nuestro panel, y las coord y van hacia abajo

            avion1.Location = new Point((int)(pixelX1 - avion1.Width / 2), (int)(pixelY1 - avion1.Height / 2));
            // le restamos a su posicion la mitad del tamano del cuadrado, para q la ubicacion quede en su mitad



            // AVION 2
            double x2 = flightplan2.GetCurrentPosition().GetX();
            double y2 = flightplan2.GetCurrentPosition().GetY();

            double pixelX2 = panel1.Width / 2 + x2;
            double pixelY2 = panel1.Height / 2 - y2;

            avion2.Location = new Point((int)(pixelX2 - avion2.Width / 2), (int)(pixelY2 - avion2.Height / 2));
        }

        private void FormEspacioAereo_Load(object sender, EventArgs e)
        {
            ColocarAviones();
            // colocamos aviones en posicion incial al abrir el form

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button(object sender, EventArgs e)
        {
            
            
        }

        private void moverButton_Click(object sender, EventArgs e)
        {
            flightplan1.Mover(cycleTime);
            flightplan2.Mover(cycleTime);
            // esto solo cambia los numeros dentro de FlightPlan
            ColocarAviones();
            // colocamos aviones en la nueva posicion
        }
    }
}

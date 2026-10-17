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

            // Dibujar la distancia de seguridad alrededor de cada avión (el avión en el centro de la elipse)
            try
            {
                if (flightplan1 != null)
                {
                    double x1 = flightplan1.GetCurrentPosition().GetX();
                    double y1 = flightplan1.GetCurrentPosition().GetY();
                    double pixelX1 = centroX + x1;
                    double pixelY1 = centroY - y1;

                    float radio1 = (float)securityDistance; // asumiendo la misma unidad que las posiciones
                    float diametro1 = radio1 * 2;
                    float izquierda1 = (float)(pixelX1 - radio1);
                    float top1 = (float)(pixelY1 - radio1);

                    e.Graphics.DrawEllipse(Pens.Red, izquierda1, top1, diametro1, diametro1 );
                }

                if (flightplan2 != null)
                {
                    double x2 = flightplan2.GetCurrentPosition().GetX();
                    double y2 = flightplan2.GetCurrentPosition().GetY();
                    double pixelX2 = centroX + x2;
                    double pixelY2 = centroY - y2;

                    float radio2 = (float)securityDistance;
                    float diametro2 = radio2 * 2;
                    float izquierda2 = (float)(pixelX2 - radio2);
                    float top2 = (float)(pixelY2 - radio2);

                    e.Graphics.DrawEllipse(Pens.Blue, izquierda2, top2, diametro2, diametro2);
                }
            }
            catch (Exception)
            {
                // lo hacemos dentro del try por si hay errores en el calculo de las posiciones, para que no se rompa el programa
            }
        }

        private void ColocarAviones()
        {
            // AVION 1

            // esto es lo que se ejecuta JUSTO al abrirse el form Espacio Aereo
            if (flightplan1 != null)
            {
                double x1 = flightplan1.GetCurrentPosition().GetX();
                double y1 = flightplan1.GetCurrentPosition().GetY();
                // leemos la posición actual del avión 1 (esto se puede hacer porque principal
                // ya nos ha pasado los vuelos con SetFlighplans)
                double pixelX1 = panel1.Width / 2 + x1; // porque x=0 es pixel 550 de nuestro panel
                double pixelY1 = panel1.Height / 2 - y1; // poruqe y=0 es pixel 400 de nuestro panel, y las coord y van hacia abajo

                avion1.Location = new Point((int)(pixelX1 - avion1.Width / 2), (int)(pixelY1 - avion1.Height / 2));
            }
            // le restamos a su posicion la mitad del tamano del cuadrado, para q la ubicacion quede en su mitad



            // AVION 2
            if (flightplan2 != null)
            {
                double x2 = flightplan2.GetCurrentPosition().GetX();
                double y2 = flightplan2.GetCurrentPosition().GetY();

                double pixelX2 = panel1.Width / 2 + x2;
                double pixelY2 = panel1.Height / 2 - y2;

                avion2.Location = new Point((int)(pixelX2 - avion2.Width / 2), (int)(pixelY2 - avion2.Height / 2));
            }

            // Fuerza el repintado del panel para que las elipses se muevan junto con los aviones
            panel1.Invalidate();


            // Si los aviones están a una distancia menor que la distancia de seguridad, mostramos un mensaje de advertencia
            if (flightplan1 != null && flightplan2 != null)
            {
                double distancia = flightplan1.Distance(flightplan2);
                if (distancia < securityDistance)
                {
                    MessageBox.Show("¡Advertencia! Los aviones están demasiado cerca. Distancia actual: " + distancia.ToString("F2"));
                }
            }
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

        private void StartAutoButton_Click(object sender, EventArgs e)
        {
            // asegura que existen flightplans configurados
            if (flightplan1 == null && flightplan2 == null) return;
            startAutoButton.Enabled = false;
            stopAutoButton.Enabled = true;
            autoTimer.Start();
        }

        private void StopAutoButton_Click(object sender, EventArgs e)
        {
            autoTimer.Stop();
            startAutoButton.Enabled = true;
            stopAutoButton.Enabled = false;
        }

        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            // mueve cada ciclo y repinta
            if (flightplan1 != null) flightplan1.Mover(cycleTime);
            if (flightplan2 != null) flightplan2.Mover(cycleTime);
            ColocarAviones();
        }

        private void DatosVuelosButton_Click(object sender, EventArgs e)
        {
            FormDatosVuelos formDatosVuelos = new FormDatosVuelos();
            formDatosVuelos.SetFlightPlans(flightplan1, flightplan2);
            formDatosVuelos.ShowDialog();
        }

        private void conflictosButton_Click(object sender, EventArgs e)
        {
            // Botón para comprobar si habrá conflicto entre los aviones en el futuro
            Boolean hayConflicto = flightplan1.PredecirConflicto(flightplan2, securityDistance, cycleTime);
            
            if (hayConflicto)
                MessageBox.Show("¡Advertencia! Se predice un conflicto entre los aviones en el futuro.");
            else
                MessageBox.Show("No se predice ningún conflicto entre los aviones en el futuro.");

        }
    }
}

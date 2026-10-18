using FlightLib;
using System;
using System.Drawing;
using System.Windows.Forms;

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


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int centroX = panel1.Width / 2;
            int centroY = panel1.Height / 2;

            // ejes X e Y, que se cruzan en el centro del panel
            e.Graphics.DrawLine(Pens.Black, 0, centroY, panel1.Width, centroY);
            e.Graphics.DrawLine(Pens.Black, centroX, 0, centroX, panel1.Height);

            // linea de trayectoria de cada vuelo, del origen al destino
            Pen myPen = new Pen(Color.Gray);

            Point origen1 = new Point((int)(centroX + flightplan1.GetInitialPosition().GetX()), (int)(centroY - flightplan1.GetInitialPosition().GetY()));
            Point destino1 = new Point((int)(centroX + flightplan1.GetFinalPosition().GetX()), (int)(centroY - flightplan1.GetFinalPosition().GetY()));
            e.Graphics.DrawLine(myPen, origen1, destino1);

            Point origen2 = new Point((int)(centroX + flightplan2.GetInitialPosition().GetX()), (int)(centroY - flightplan2.GetInitialPosition().GetY()));
            Point destino2 = new Point((int)(centroX + flightplan2.GetFinalPosition().GetX()), (int)(centroY - flightplan2.GetFinalPosition().GetY()));
            e.Graphics.DrawLine(myPen, origen2, destino2);

            myPen.Dispose();

            // círculo de seguridad alrededor de cada avión.
            // draw elipse usa la esquina de arriba a la izquierda, por eso le restamos el radio
            float radio = (float)securityDistance;

            float esquinaX1 = (float)(centroX + flightplan1.GetCurrentPosition().GetX() - radio);
            float esquinaY1 = (float)(centroY - flightplan1.GetCurrentPosition().GetY() - radio);
            e.Graphics.DrawEllipse(Pens.Red, esquinaX1, esquinaY1, 2 * radio, 2 * radio);

            float esquinaX2 = (float)(centroX + flightplan2.GetCurrentPosition().GetX() - radio);
            float esquinaY2 = (float)(centroY - flightplan2.GetCurrentPosition().GetY() - radio);
            e.Graphics.DrawEllipse(Pens.Blue, esquinaX2, esquinaY2, 2 * radio, 2 * radio);
        }

      

        private void ColocarAviones()
        {
            // AVION 1

            //se ejecuta al abrir el formulario y cada vez que se mueven los aviones
            if (flightplan1 != null)
            {
                double x1 = flightplan1.GetCurrentPosition().GetX();
                double y1 = flightplan1.GetCurrentPosition().GetY();
                // leemos la posición actual del avión 1 (esto se puede hacer porque principal
                // ya nos ha pasado los vuelos con SetFlighplans)
                double pixelX1 = panel1.Width / 2 + x1; // el (0,0) de nuestros ejes está en el centro del panel
                double pixelY1 = panel1.Height / 2 - y1; // restamos porque en Windows la Y crece hacia abajo

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

            
            panel1.Invalidate();


            // si se acercan más que la distancia de seguridad, salta un aviso
            // paramos antes la simulación automática porque sino el timer seguiria
            double distancia = flightplan1.Distance(flightplan2);
            if (distancia < securityDistance)
            {
                autoTimer.Stop();
                startAutoButton.Enabled = true;
                stopAutoButton.Enabled = false;
                MessageBox.Show("¡Cuidado! Los aviones están demasiado cerca. Distancia actual: " + distancia.ToString("F2"));
            }
        }

        private void FormEspacioAereo_Load(object sender, EventArgs e)
        {
            //guardamos en cada avión su plan de vuelo para saber cuál es al hacer clic
            avion1.Tag = flightplan1;
            avion2.Tag = flightplan2;

            //al hacer clic en un avión se ejecuta  flight information
            avion1.Click += FlightInformation;
            avion2.Click += FlightInformation;
            // antes de empezar, comprobamos si habrá conflicto
            if (flightplan1.PredecirConflicto(flightplan2, securityDistance, cycleTime))
            {
                DialogResult respuesta = MessageBox.Show(
                    "Los vuelos entrarán en conflicto. ¿Quieres resolverlo automáticamente?",
                    "Conflicto detectado",
                    MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    ResolverConflicto();
                }
            }
            ColocarAviones();
            // colocamos aviones en posicion incial al abrir el form

        }
        // si hay conflicto, cambia la velocidad de un vuelo para evitar el conflicto
        private void ResolverConflicto()
        {
            double velocidadOriginal = flightplan2.GetVelocidad();
            double nuevaVelocidad = velocidadOriginal;

            //bajamos la velocidad del avión 2 un 10% cada vez, mientras siga habiendo conflicto
            // con un límite: el10% de su velocidad original, por si el conflicto no tiene solicion
            while (flightplan1.PredecirConflicto(flightplan2, securityDistance, cycleTime)
                   && nuevaVelocidad > velocidadOriginal * 0.1)
            {
                nuevaVelocidad = nuevaVelocidad * 0.9;
                flightplan2.SetVelocidad(nuevaVelocidad);
            }

            // comprobamos si lo hemos conseguido
            if (flightplan1.PredecirConflicto(flightplan2, securityDistance, cycleTime))
            {
                flightplan2.SetVelocidad(velocidadOriginal); // no se ha podido: dejamos la velocidad como estaba
                MessageBox.Show("No se ha podido resolver el conflicto cambiando la velocidad.");
            }
            else
            {
                MessageBox.Show("Conflicto resuelto. Nueva velocidad del vuelo " + flightplan2.GetId() + ": " + nuevaVelocidad.ToString("F2"));
            }
        }
        

        

       

        private void moverButton_Click(object sender, EventArgs e)
        {
            flightplan1.Mover(cycleTime);
            flightplan2.Mover(cycleTime);
            // esto solo cambia los numeros dentro de FlightPlan
            ColocarAviones();
            // colocamos aviones en la nueva posicion
        }
        private void FlightInformation(object sender, EventArgs e)
        {
            // Se ejecuta al hacer clic en un avión.
            // El sender es el PictureBox (avión) en el que se ha hecho clic
            PictureBox avion = (PictureBox)sender;
            FlightPlan flightplan = (FlightPlan)avion.Tag; // recuperamos el vuelo guardado en el Tag
            FlightInfo flightInfoForm = new FlightInfo();
            flightInfoForm.SetFlightPlan(flightplan);
            flightInfoForm.ShowDialog();
        }
        private void StartAutoButton_Click(object sender, EventArgs e)
        {
            
            
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
            // Cuando los dos han llegado ya no tiene sentido seguir, paramos la simulación
            if (flightplan1.HasArrived() && flightplan2.HasArrived())
            {
                autoTimer.Stop();
                startAutoButton.Enabled = true;
                stopAutoButton.Enabled = false;
            }
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

        private void avion2_Click(object sender, EventArgs e)
        {

        }
    }
}

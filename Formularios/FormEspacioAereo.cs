using FlightLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormEspacioAereo : Form
    {
        FlightPlanList lista; // lista de planes de vuelo
        List<PictureBox> aviones = new List<PictureBox>(); // un picturebox por vuelo, con el mismo orden que la lista
        double securityDistance;
        int cycleTime;

        // color de cada vuelo (si hay más vuelos que colores, se repiten)
        Color[] colores = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

        public FormEspacioAereo()
        {
            InitializeComponent();
        }

        
        // Recibe la lista de vuelos desde Principal
        public void SetFlightPlans(FlightPlanList l)
        {
            lista = l;
        }

        // Recibe la configuración desde Principal
        public void SetConfig(double sd , int ct )
        {
            securityDistance = sd;
            cycleTime = ct;
            // asi guardamos la informacion que recibimos de principal
        }

        // Crea un PictureBox por vuelo. avion1 se usa como plantilla para el resto
        private void CrearAviones()
        {
            for (int i = 0; i < lista.GetNumber(); i++)
            {
                PictureBox pb;
                if (i == 0)
                {
                    pb = avion1;
                }
                else
                {
                    pb = new PictureBox();
                    pb.Image = avion1.Image;
                    pb.Size = avion1.Size;
                    pb.SizeMode = avion1.SizeMode;
                    pb.BackColor = avion1.BackColor;
                    panel1.Controls.Add(pb);
                }
                pb.Tag = lista.GetFlightPlan(i); // guardamos el vuelo para FlightInformation
                pb.Click += FlightInformation;
                aviones.Add(pb);
            }
        }

        // Dibuja trayectorias y círculos de seguridad de todos los vuelos
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int centroX = panel1.Width / 2;
            int centroY = panel1.Height / 2;
            float radio = (float)securityDistance;


            // linea de trayectoria de cada vuelo, del origen al destino
            Pen lineaGris = new Pen(Color.Gray);

            for (int i = 0; i < lista.GetNumber(); i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                Point origen = new Point((int)(centroX + f.GetInitialPosition().GetX()), (int)(centroY - f.GetInitialPosition().GetY()));
                Point destino = new Point((int)(centroX + f.GetFinalPosition().GetX()), (int)(centroY - f.GetFinalPosition().GetY()));
                e.Graphics.DrawLine(lineaGris, origen, destino);
            }

            lineaGris.Dispose();

            // relleno rojo suave en los vuelos que están en conflicto
            for (int i = 0; i < lista.GetNumber(); i++)
            {
                if (lista.EstaEnConflicto(i, securityDistance))
                {
                    FlightPlan f = lista.GetFlightPlan(i);
                    float esquinaX = (float)(centroX + f.GetCurrentPosition().GetX() - radio);
                    float esquinaY = (float)(centroY - f.GetCurrentPosition().GetY() - radio);
                    SolidBrush relleno = new SolidBrush(Color.FromArgb(70, Color.Red));
                    e.Graphics.FillEllipse(relleno, esquinaX, esquinaY, 2 * radio, 2 * radio);
                    relleno.Dispose();
                }

            }

            // borde de cada círculo, dibujado por encima del relleno
            for (int i = 0; i < lista.GetNumber(); i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                float esquinaX = (float)(centroX + f.GetCurrentPosition().GetX() - radio);
                float esquinaY = (float)(centroY - f.GetCurrentPosition().GetY() - radio);
                Pen borde = new Pen(colores[i % colores.Length]);
                e.Graphics.DrawEllipse(borde, esquinaX, esquinaY, 2 * radio, 2 * radio);
                borde.Dispose();
            }

        }
        

      
        // Coloca cada avión en su posición actual y repinta
        // Si hay conflicto en el instante actual, la simulación automática se para
        // Se ejecuta al abrir el formulario y al mover los aviones
        private void ColocarAviones()
        {
            int centroX = panel1.Width / 2;
            int centroY = panel1.Height / 2;

            
            for (int i = 0; i < aviones.Count; i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                double pixelX = centroX + f.GetCurrentPosition().GetX(); // el (0,0) de nuestros ejes está en el centro del panel
                double pixelY = centroY - f.GetCurrentPosition().GetY(); // restamos porque en Windows la Y crece hacia abajo
                
                // le restamos a su posicion la mitad del tamano del cuadrado, para q la ubicacion quede en su mitad
                aviones[i].Location = new Point((int)(pixelX - aviones[i].Width / 2), (int)(pixelY - aviones[i].Height / 2));
            }
            
            
            panel1.Invalidate();


            // si un par de vuelos (o más) se acercan a una distancia menor que la de seguridad
            // paramos la simulación automática porque sino el timer seguiria
            if (lista.HayConflicto(securityDistance))
            {
                autoTimer.Stop();
                startAutoButton.Enabled = true;
                stopAutoButton.Enabled = false;
            }
        }

        // Crea los aviones, avisa si hay conflicto previsto y coloca los aviones
        private void FormEspacioAereo_Load(object sender, EventArgs e)
        {
            CrearAviones();

            // antes de empezar, comprobamos si habrá conflicto, si lo hay y el usuario quiere resolverlo se intenta resolver
            if (lista.PredecirConflictos(securityDistance, cycleTime))
            {
                DialogResult respuesta = MessageBox.Show(
                    "Los vuelos entrarán en conflicto. ¿Quieres resolverlo automáticamente?",
                    "Conflicto detectado",
                    MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    bool res = lista.ResolverConflictos(securityDistance, cycleTime);
                    if (!res)
                        MessageBox.Show("No se ha podido resolver el conflicto automáticamente. Se mantendrán las velocidades originales.");
                    else
                        MessageBox.Show("Se ha resuelto el conflicto automáticamente. Se han ajustado las velocidades de los vuelos.");
                }

            }
            // colocamos aviones en posicion incial al abrir el form
            ColocarAviones();
        } 

        private void moverButton_Click(object sender, EventArgs e)
        {
            lista.Mover(cycleTime);
            // esto solo cambia los numeros dentro de FlightPlan
            ColocarAviones();
            deshacerButton.Enabled = lista.PuedeDeshacer();
            // colocamos aviones en la nueva posicion
        }

        // Restaura las posiciones anteriores al último ciclo de simulación.
        private void deshacerButton_Click(object sender, EventArgs e)
        {
            autoTimer.Stop();
            startAutoButton.Enabled = true;
            stopAutoButton.Enabled = false;

            if (lista.DeshacerUltimoPaso())
                ColocarAviones();

            deshacerButton.Enabled = lista.PuedeDeshacer();
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
        // Inicia la simulación automática
        private void StartAutoButton_Click(object sender, EventArgs e)
        {
            startAutoButton.Enabled = false;
            stopAutoButton.Enabled = true;
            autoTimer.Start();
        }
        // Para la simulación automática
        private void StopAutoButton_Click(object sender, EventArgs e)
        {
            autoTimer.Stop();
            startAutoButton.Enabled = true;
            stopAutoButton.Enabled = false;
        }
        // Mueve todos los vuelos cada ciclo y repinta.
        // Cuando todos han llegado, para la simulación ya que no tiene sentido seguir
        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            lista.Mover(cycleTime);
            ColocarAviones();
            deshacerButton.Enabled = lista.PuedeDeshacer();

            if (lista.HanLlegadoTodos())
            {
                autoTimer.Stop();
                startAutoButton.Enabled = true;
                stopAutoButton.Enabled = false;
            }
        }

        private void DatosVuelosButton_Click(object sender, EventArgs e)
        {
            FormDatosVuelos formDatosVuelos = new FormDatosVuelos();
            formDatosVuelos.SetFlightPlans(lista);
            formDatosVuelos.ShowDialog();
        }

        // Comprueba si habrá conflicto entre algún par de vuelos en el futuro
        private void conflictosButton_Click(object sender, EventArgs e)
        {
            if (lista.PredecirConflictos(securityDistance, cycleTime))
                MessageBox.Show("¡Advertencia! Se predice un conflicto entre los aviones en el futuro.");
            else
                MessageBox.Show("No se predice ningún conflicto entre los aviones en el futuro.");
        }


        // Devuelve todos los vuelos a su posición inicial
        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            autoTimer.Stop();
            startAutoButton.Enabled = true;
            stopAutoButton.Enabled = false;
            lista.Reiniciar();
            ColocarAviones();
            deshacerButton.Enabled = lista.PuedeDeshacer();
        }

        private void cambiarVelocidadesButton_Click(object sender, EventArgs e)
        {
            
            autoTimer.Stop();
            startAutoButton.Enabled = true;
            stopAutoButton.Enabled = false;

            FormCambiarVelocidades formVelocidades = new FormCambiarVelocidades();
            formVelocidades.SetFlightPlans(lista);
            formVelocidades.ShowDialog();

            
            if (formVelocidades.GetCambiado())
            {
                lista.Reiniciar();
                ColocarAviones();
                deshacerButton.Enabled = lista.PuedeDeshacer();

                if (lista.PredecirConflictos(securityDistance, cycleTime))
                    MessageBox.Show("Con estas velocidades los vuelos siguen entrando en conflicto.");
                else
                    MessageBox.Show("Con estas velocidades ya no hay conflicto.");
            }
        }
    }
}

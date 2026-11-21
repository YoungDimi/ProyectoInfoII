using FlightLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Formularios
{
    // ventana donde se ven los aviones moviendose
    public partial class FormEspacioAereo : Form
    {
        FlightPlanList lista;
        List<PictureBox> aviones = new List<PictureBox>(); // un picturebox por vuelo, en el mismo orden que la lista
        double securityDistance;
        int cycleTime;

        // un color por vuelo, si hay mas vuelos se repiten
        Color[] colores = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

        public FormEspacioAereo()
        {
            InitializeComponent();
        }

        // recibe la lista de vuelos desde principal
        public void SetFlightPlans(FlightPlanList l)
        {
            lista = l;
        }

        // recibe la distancia de seguridad y el tiempo de ciclo desde principal
        public void SetConfig(double sd , int ct )
        {
            securityDistance = sd;
            cycleTime = ct;
        }

        // crea un picturebox por vuelo copiando avion1
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
                pb.Tag = lista.GetFlightPlan(i); // guardamos el vuelo para luego saber cual se ha clicado
                pb.Click += FlightInformation;
                aviones.Add(pb);
            }
        }

        // dibuja las trayectorias y los circulos de seguridad
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int centroX = panel1.Width / 2;
            int centroY = panel1.Height / 2;
            float radio = (float)securityDistance;

            // linea gris del origen al destino de cada vuelo
            Pen lineaGris = new Pen(Color.Gray);

            for (int i = 0; i < lista.GetNumber(); i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                Point origen = new Point((int)(centroX + f.GetInitialPosition().GetX()), (int)(centroY - f.GetInitialPosition().GetY()));
                Point destino = new Point((int)(centroX + f.GetFinalPosition().GetX()), (int)(centroY - f.GetFinalPosition().GetY()));
                e.Graphics.DrawLine(lineaGris, origen, destino);
            }

            lineaGris.Dispose();

            // circulo rojo clarito en los vuelos que estan en conflicto
            SolidBrush relleno = new SolidBrush(Color.FromArgb(70, Color.Red));

            for (int i = 0; i < lista.GetNumber(); i++)
            {
                if (lista.EstaEnConflicto(i, securityDistance))
                {
                    FlightPlan f = lista.GetFlightPlan(i);
                    float esquinaX = (float)(centroX + f.GetCurrentPosition().GetX() - radio);
                    float esquinaY = (float)(centroY - f.GetCurrentPosition().GetY() - radio);
                    e.Graphics.FillEllipse(relleno, esquinaX, esquinaY, 2 * radio, 2 * radio);
                }
            }

            relleno.Dispose();

            // borde de cada circulo, por encima del relleno
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

        // pone cada avion en su posicion actual y repinta
        // si ahora mismo hay conflicto para el timer y enseña la alarma
        private void ColocarAviones()
        {
            int centroX = panel1.Width / 2;
            int centroY = panel1.Height / 2;

            for (int i = 0; i < aviones.Count; i++)
            {
                FlightPlan f = lista.GetFlightPlan(i);
                double pixelX = centroX + f.GetCurrentPosition().GetX(); // el (0,0) esta en el centro del panel
                double pixelY = centroY - f.GetCurrentPosition().GetY(); // se resta porque en windows la y va hacia abajo

                // restamos la mitad del tamaño para que el avion quede centrado en su punto
                aviones[i].Location = new Point((int)(pixelX - aviones[i].Width / 2), (int)(pixelY - aviones[i].Height / 2));
            }

            panel1.Invalidate();

            // alarma
            if (lista.HayConflicto(securityDistance))
            {
                autoTimer.Stop();
                startAutoButton.Enabled = true;
                stopAutoButton.Enabled = false;
                alarmLabel.Visible = true;
            }
            else
            {
                alarmLabel.Visible = false;
            }
        }

        // al abrir crea los aviones, mira si habra conflicto y los coloca
        private void FormEspacioAereo_Load(object sender, EventArgs e)
        {
            CrearAviones();

            // si se predice conflicto preguntamos si se quiere resolver
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
            ColocarAviones();
        }

        // mueve un ciclo
        private void moverButton_Click(object sender, EventArgs e)
        {
            lista.Mover(cycleTime);
            ColocarAviones();
        }

        // al clicar un avion abre la ventana con sus datos
        private void FlightInformation(object sender, EventArgs e)
        {
            PictureBox avion = (PictureBox)sender;
            FlightPlan flightplan = (FlightPlan)avion.Tag; // el vuelo que guardamos en el tag
            FlightInfo flightInfoForm = new FlightInfo();
            flightInfoForm.SetFlightPlan(flightplan);
            flightInfoForm.ShowDialog();
        }

        // empieza la simulacion automatica
        private void StartAutoButton_Click(object sender, EventArgs e)
        {
            startAutoButton.Enabled = false;
            stopAutoButton.Enabled = true;
            autoTimer.Start();
        }

        // para la simulacion automatica
        private void StopAutoButton_Click(object sender, EventArgs e)
        {
            autoTimer.Stop();
            startAutoButton.Enabled = true;
            stopAutoButton.Enabled = false;
        }

        // cada tick mueve un ciclo, y si ya han llegado todos para
        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            lista.Mover(cycleTime);
            ColocarAviones();

            if (lista.HanLlegadoTodos())
            {
                autoTimer.Stop();
                startAutoButton.Enabled = true;
                stopAutoButton.Enabled = false;
            }
        }

        // abre la tabla con los datos de los vuelos
        private void DatosVuelosButton_Click(object sender, EventArgs e)
        {
            FormDatosVuelos formDatosVuelos = new FormDatosVuelos();
            formDatosVuelos.SetFlightPlans(lista);
            formDatosVuelos.ShowDialog();
        }

        // dice si habra conflicto mas adelante
        private void conflictosButton_Click(object sender, EventArgs e)
        {
            if (lista.PredecirConflictos(securityDistance, cycleTime))
                MessageBox.Show("¡Advertencia! Se predice un conflicto entre los aviones en el futuro.");
            else
                MessageBox.Show("No se predice ningún conflicto entre los aviones en el futuro.");
        }

        // vuelve todos los vuelos al principio
        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            lista.Reiniciar();
            ColocarAviones();
        }

        // para la simulacion y abre la ventana de velocidades
        // si se han cambiado se reinicia y se vuelve a mirar si hay conflicto
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

                if (lista.PredecirConflictos(securityDistance, cycleTime))
                    MessageBox.Show("Con estas velocidades los vuelos siguen entrando en conflicto.");
                else
                    MessageBox.Show("Con estas velocidades ya no hay conflicto.");
            }
        }

        // deshace el ultimo movimiento
        private void atrasButton_Click(object sender, EventArgs e)
        {
            if (lista.Retroceder() == true)
            {
                autoTimer.Stop();
                startAutoButton.Enabled = true;
                stopAutoButton.Enabled = false;
                ColocarAviones();
            }
        }

        // para la simulacion, guarda los vuelos en un fichero y cierra
        private void guardarYSalirButton_Click(object sender, EventArgs e)
        {
            autoTimer.Stop();
            startAutoButton.Enabled = true;
            stopAutoButton.Enabled = false;

            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt";
            dialogo.Title = "Guardar la simulación";
            dialogo.FileName = "simulacion_guardada.txt";

            if (dialogo.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                lista.GuardarEnArchivo(dialogo.FileName);
                MessageBox.Show("Simulación guardada. Carga este fichero más adelante para continuar desde aquí.");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido guardar el fichero.");
            }
        }
    }

}

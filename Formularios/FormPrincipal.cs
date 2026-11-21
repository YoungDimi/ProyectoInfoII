using FlightLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Formularios
{
    public partial class Principal : Form
    {
        FlightPlanList lista; // lista de planes de vuelo
        double securityDistance;
        int cycleTime;
        public Principal()
        {
            InitializeComponent();
        }

        // Pide al usuario un fichero de texto con los planes de vuelo y los carga en la lista.
        // Si el fichero tiene errores, los muestra y no cambia la lista.
        private void introducirPlanesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt";
            dialogo.Title = "Selecciona el fichero con los planes de vuelo";

            if (dialogo.ShowDialog() != DialogResult.OK)
                return;

            FlightPlanList nueva = new FlightPlanList();
            try
            {
                List<string> errores = nueva.CargarDesdeArchivo(dialogo.FileName);

                if (errores.Count > 0)
                {
                    // juntamos todos los errores en un solo mensaje, uno por línea
                    string mensaje = "El fichero tiene errores y no se ha cargado:\n\n";
                    for (int i = 0; i < errores.Count; i++)
                        mensaje = mensaje + errores[i] + "\n";

                    MessageBox.Show(mensaje, "Error en el fichero");
                    return;
                }

                lista = nueva; // si no hay errores, nos quedamos con la lista nueva
                MessageBox.Show("Se han cargado " + lista.GetNumber() + " planes de vuelo.", "Carga correcta");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el fichero.", "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido leer el fichero.", "Error");
            }
        }

        private void configuraciónDelSimuladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddConfig formAddConfig = new FormAddConfig();
            formAddConfig.SetSecurityDistance(securityDistance);
            formAddConfig.SetCycleTime(cycleTime);
            formAddConfig.ShowDialog();

            securityDistance = formAddConfig.GetSecurityDistance();
            cycleTime = formAddConfig.GetCycleTime();
        }

       

        private void espacioAereoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // primero comprobamos que hay vuelos y que el simulador está configurado
            if (lista == null || lista.GetNumber() == 0)
            {
                MessageBox.Show("Introduce los planes de vuelo primero.");
                return;
            }
            if (cycleTime <= 0)
            {
                MessageBox.Show("Configura primero el simulador (tiempo de ciclo y distancia de seguridad).");
                return;
            }
            // ahora si, podemos abrir el nuevo form
            FormEspacioAereo formEspacioAereo = new FormEspacioAereo();


            // le pasamamos al formEspacioAereo la informacion
            formEspacioAereo.SetFlightPlans(lista);
            formEspacioAereo.SetConfig(securityDistance, cycleTime);
            //ahora q ya ha recibido la info podemos abrir el formespacio aereo
            formEspacioAereo.ShowDialog();

        }
    }
}

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

        // Pide al usuario un archivo de texto con los planes de vuelo y los carga en la lista
        // Si tiene errores, los muestra en un MessageBox y no cambia la lista
        private void introducirPlanesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            dialogo.Title = "Selecciona un archivo de texto con los planes de vuelo";

            if (dialogo.ShowDialog() != DialogResult.OK)
                return;

            FlightPlanList nueva = new FlightPlanList();
            try
            {
                List<string> errores = nueva.CargarDesdeArchivo(dialogo.FileName);

                if (errores.Count > 0)
                {
                    MessageBox.Show("El fichero tiene errores y no se ha cargado:\n\n" + string.Join("\n", errores),
                "Error en el fichero");
                    return;
                }

                lista = nueva; // si no hay errores, cambiamos la lista
                MessageBox.Show("Se han cargado correctamente " + lista.GetNumber() + " planes de vuelo.", "Carga correcta");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el archivo.", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo: " + ex.Message, "Error");
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

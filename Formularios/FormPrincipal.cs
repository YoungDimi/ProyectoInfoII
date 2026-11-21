using FlightLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Formularios
{
    // ventana principal con el menu
    public partial class Principal : Form
    {
        FlightPlanList lista;
        double securityDistance;
        int cycleTime;

        public Principal()
        {
            InitializeComponent();
        }

        // carga los vuelos de un fichero de texto
        // si el fichero tiene errores los enseña y no cambia la lista
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
                    // un error por linea
                    string mensaje = "El fichero tiene errores y no se ha cargado:\n\n";
                    for (int i = 0; i < errores.Count; i++)
                        mensaje = mensaje + errores[i] + "\n";

                    MessageBox.Show(mensaje, "Error en el fichero");
                    return;
                }

                lista = nueva;
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

        // abre la ventana de configuracion y luego recoge los valores
        private void configuraciónDelSimuladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddConfig formAddConfig = new FormAddConfig();
            formAddConfig.SetSecurityDistance(securityDistance);
            formAddConfig.SetCycleTime(cycleTime);
            formAddConfig.ShowDialog();

            securityDistance = formAddConfig.GetSecurityDistance();
            cycleTime = formAddConfig.GetCycleTime();
        }

        // abre el espacio aereo si ya hay vuelos y configuracion
        private void espacioAereoToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

            FormEspacioAereo formEspacioAereo = new FormEspacioAereo();
            formEspacioAereo.SetFlightPlans(lista);
            formEspacioAereo.SetConfig(securityDistance, cycleTime);
            formEspacioAereo.ShowDialog();

        }
    }
}

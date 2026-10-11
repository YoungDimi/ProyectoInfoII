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
    public partial class Principal : Form
    {
        FlightPlan flightplan1;
        FlightPlan flightplan2;
        double securityDistance;
        int cycleTime;
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void introducirPlanesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddFlightPlans formAddFlightPlans = new FormAddFlightPlans();
            formAddFlightPlans.ShowDialog();
            flightplan1 = formAddFlightPlans.GetFlightPlan1();
            flightplan2 = formAddFlightPlans.GetFlightPlan2();
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

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       

        private void espacioAereoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // primero comprobamos que realmente se hayan introducido los datos de los dos flightplans
            if (flightplan1 == null || flightplan2 == null)
            {
                MessageBox.Show("Introduce los planes de vuelo primero.");
                return;
            }

            // ahora si, podemos abrir el nuevo form
            FormEspacioAereo formEspacioAereo = new FormEspacioAereo();


            //asi le pasamamos al formEspacioAereo la informacion
            formEspacioAereo.SetFlightPlans(flightplan1, flightplan2); 
            formEspacioAereo.SetConfig(securityDistance, cycleTime);
            //ahora q ya ha recibido la info podemos abrir el formespacio aereo
            formEspacioAereo.ShowDialog();


            

        }
    }
}

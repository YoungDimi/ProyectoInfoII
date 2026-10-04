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
    }
}

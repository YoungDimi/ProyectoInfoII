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
    public partial class FlightInfo : Form
    {
        FlightPlan myflight;

        public void SetFlightPlan(FlightPlan f)
        {
           this.myflight = f;
        }
        public FlightInfo()
        {
            InitializeComponent();
        }

        private void FlightInfo_Load(object sender, EventArgs e)
        {
            Xbox.Text = Convert.ToString(myflight.GetCurrentPosition().GetX());
            Ybox.Text = Convert.ToString(myflight.GetCurrentPosition().GetY());
            Speedbox.Text = Convert.ToString(myflight.GetVelocidad());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }   
}

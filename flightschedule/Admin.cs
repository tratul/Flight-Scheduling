using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flightschedule
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_info fl = new Flight_info();
            fl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flight_update fl = new Flight_update();
            fl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_info fl = new Customer_info();
            fl.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Booking_flight fl = new Booking_flight();
            fl.Show();
        }
    }
}

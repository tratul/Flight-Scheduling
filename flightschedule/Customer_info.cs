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
    public partial class Customer_info : Form
    {
        public Customer_info()
        {
            InitializeComponent();
        }

        private void Customer_info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flight_bookingDataSet.customer_detail' table. You can move, or remove it, as needed.
            this.customer_detailTableAdapter.Fill(this.flight_bookingDataSet.customer_detail);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin ad = new Admin();
            ad.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

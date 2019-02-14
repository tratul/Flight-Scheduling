using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace flightschedule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            lgn.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PRPMMA8\HASANDB;Initial Catalog=Flight_booking;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("select * from Flight_details where Source='" + comboBox1.Text + "' and Destination='" + comboBox2.Text + "' and Departure='"+textBox1.Text+"' and Seats > '"+Convert.ToInt32(textBox2.Text)+"' and Date='"+ Convert.ToString(dateTimePicker1.Text) +"'" , con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //Convert.ToInt32
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Customer cs = new Customer();
            //cs.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'flight_bookingDataSet1.Flight_Details' table. You can move, or remove it, as needed.
            this.flight_DetailsTableAdapter.Fill(this.flight_bookingDataSet1.Flight_Details);

        }
    }
}

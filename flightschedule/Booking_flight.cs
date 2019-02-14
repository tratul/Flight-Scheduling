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
    public partial class Booking_flight : Form
    {
        public Booking_flight()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PRPMMA8\HASANDB;Initial Catalog=Flight_booking;Integrated Security=True");
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Booking where DateofJourney='" + Convert.ToString(dateTimePicker1.Text) + "'", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text != null)
                {
                    int x = Convert.ToInt32(textBox1.Text);
                    con.Open();
                    String str = "delete from Booking where TicketId='" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    String st = "update  Flight_Details set Seats= Seats+@x where Id= (select FlightId from Booking where TicketId='" + Convert.ToInt32(textBox1.Text) + "') ";
                    SqlCommand cm = new SqlCommand(str, con);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("1 Booking is deleted");
                    this.Hide();
                    Admin lgn = new Admin();
                    lgn.Show();
                }
                else
                {
                    MessageBox.Show("fill the box !!!");
                }
            }
            else
                label2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin lgn = new Admin();
            lgn.Show();
        }
    }
}

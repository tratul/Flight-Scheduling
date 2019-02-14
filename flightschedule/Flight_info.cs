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
    public partial class Flight_info : Form
    {
        public Flight_info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                if (textBox1.Text != null && comboBox1.Text != null && comboBox2.Text != null && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null && textBox7.Text != null && textBox8.Text != null)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PRPMMA8\HASANDB;Initial Catalog=Flight_booking;Integrated Security=True");
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        String str = "insert into Flight_Details(Flight_Name,Source,Destination,Arrival_Time,Departure,Flight_Class,Flight_charges,Seats,Date) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + Convert.ToString(dateTimePicker1.Text) + "' )";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("1 Flight is added");
                        this.Hide();
                        Admin lgn = new Admin();
                        lgn.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter all data");
                }
            }
            else
            {
                label10.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin lgn = new Admin();
            lgn.Show();
        }
    }
}

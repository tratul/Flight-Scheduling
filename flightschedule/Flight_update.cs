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
    public partial class Flight_update : Form
    {
        public Flight_update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin lgn = new Admin();
            lgn.Show();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PRPMMA8\HASANDB;Initial Catalog=Flight_booking;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                if (textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null)
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        String str = "update  Flight_Details set Arrival_Time='" + textBox3.Text + "',Departure='" + textBox4.Text + "',Flight_charges='" + textBox5.Text + "',Seats='" + Convert.ToInt32(textBox6.Text) + "' where Id = '" + Convert.ToInt32(textBox2.Text) + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("1 Flight is updated");
                        this.Hide();
                        Admin lgn = new Admin();
                        lgn.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Enter all required DATA !!!");
                }
            }
            else
            {
                label6.Visible = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
                SqlDataAdapter sda = new SqlDataAdapter("select * from Flight_details where Date='" + Convert.ToString(dateTimePicker1.Text)+ "'", con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

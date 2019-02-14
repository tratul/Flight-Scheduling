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
    public partial class Login : Form
    {
        string x;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PRPMMA8\HASANDB;Initial Catalog=Flight_booking;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*)From customer_detail where name='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                //x = dt.Rows[0][0].ToString();
                // MessageBox.Show(x);
                con.Open();
                String s = "Select id From customer_detail where name='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    x = (dr["id"].ToString());
                    MessageBox.Show(x);
                }
                else
                { MessageBox.Show("error in inner"); }
                    this.Hide();
                    Ticket_Reservation lgn = new Ticket_Reservation(x);
                    lgn.Show();
                
            }
            else if (textBox1.Text == "Admin" && textBox2.Text == "Admin")
            {
                MessageBox.Show("You are login as Admin");
                this.Hide();
                Admin lgn = new Admin();
                lgn.Show();
            }
            else
            {
                MessageBox.Show("Please check Your Username and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer lgn = new Customer();
            lgn.Show();
        }
    }
}

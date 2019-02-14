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
    public partial class Ticket_Reservation : Form
    {
        public Ticket_Reservation()
        {
            
        }
        string x;
        public Ticket_Reservation(string a)
        {
            x = a;
            InitializeComponent();
            Load();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PRPMMA8\HASANDB;Initial Catalog=Flight_booking;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != comboBox2.Text)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Flight_details where Source='"+comboBox1.Text+"' and Destination='"+comboBox2.Text+"'",con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }
        }
        public void Load()
        {
             con.Open();
             if (con.State == ConnectionState.Open)
             {
                 SqlDataAdapter sda = new SqlDataAdapter("select * from customer_detail where Id='" + Convert.ToInt32(x) + "'", con);
                 DataTable data = new DataTable();
                 sda.Fill(data);
                 textBox4.Text = data.Rows[0][1].ToString();
                 textBox5.Text = data.Rows[0][2].ToString();
                 textBox6.Text = data.Rows[0][3].ToString();
                 textBox7.Text = data.Rows[0][4].ToString();
                 textBox8.Text = data.Rows[0][5].ToString();
                 textBox9.Text = data.Rows[0][6].ToString();
             }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //con.Open();
            //if (con.State == ConnectionState.Open)
            //{
            //    SqlDataAdapter sda = new SqlDataAdapter("select * from customer_detail where Id='"+Convert.ToInt32(textBox3.Text)+"'", con);
            //    DataTable data = new DataTable();
            //    sda.Fill(data);
            //    textBox4.Text = data.Rows[0][1].ToString();
            //    textBox5.Text = data.Rows[0][2].ToString();
            //    textBox6.Text = data.Rows[0][3].ToString();
            //    textBox7.Text = data.Rows[0][4].ToString();
            //    textBox8.Text = data.Rows[0][5].ToString();
            //    textBox9.Text = data.Rows[0][6].ToString();
                
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //con.Open();
            if (textBox11.Text != "" && textBox12.Text != "" )
            {
                if (textBox11.Text != null && textBox12.Text != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        String str = "insert into Booking(CustomerId,DateofJourney,FlightId,Seatno) values('" + Convert.ToInt32(textBox3.Text) + "', '" + Convert.ToString(dateTimePicker1.Text) + "','" + Convert.ToInt32(textBox11.Text) + "','" + Convert.ToInt32(textBox12.Text) + "' )";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        String st = "update  Flight_Details set Seats= Seats-@x where Id='" + Convert.ToInt32(textBox11.Text) + "') ";
                        SqlCommand cm = new SqlCommand(str, con);
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Your seat is booked");
                        this.Hide();
                        Ticket_Reservation lgn = new Ticket_Reservation();
                        lgn.Show();

                        //Ticket_Reservation_Load(sender,e);
                    }
                }
                else
                {
                    MessageBox.Show("Enter all required DATA !!!");
                }
            }
            else
            {
                label11.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 lgn = new Form1();
            lgn.Show();
        }
    }
}

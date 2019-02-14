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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                if (label10.Visible == true || label11.Visible == true)
                {
                    label10.Visible = false;
                    label11.Visible = false;
                }
                if (textBox5.Text.Contains("@") && textBox5.Text.Contains(".com"))
                {
                    if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null && textBox7.Text != null)
                    {
                        if (textBox2.Text == textBox3.Text)
                        {
                            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PRPMMA8\HASANDB;Initial Catalog=Flight_booking;Integrated Security=True");
                            con.Open();
                            if (con.State == ConnectionState.Open)
                            {
                                String str = "insert into customer_detail(name,fatherName,birth,email,phone,address,password) values('" + textBox1.Text + "','" + textBox4.Text + "','" + Convert.ToString(dateTimePicker1.Text) + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "' ,'" + textBox2.Text + "' )";
                                SqlCommand cmd = new SqlCommand(str, con);
                                cmd.ExecuteNonQuery();
                                this.Hide();
                                Login lgn = new Login();
                                lgn.Show();
                            }
                        }
                        else
                        {
                            label9.Show();
                            label9.Text = "Password Incorrect";
                        }

                    }
                    else
                    {
                        MessageBox.Show("Enter all required DATA !!!");
                    }
                }
                else
                {
                    label10.Visible = true;

                }
            }
            else
            {
                label11.Visible = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            lgn.Show();
        }
    }
}

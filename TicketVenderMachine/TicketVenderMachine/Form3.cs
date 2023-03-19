using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketVenderMachine
{
    public partial class Form3 : Form
    {

        SqlConnection cn;
        SqlDataAdapter data;
        SqlCommand cm;
        DataTable tb;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

           

            SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=machine;Integrated Security=True"); // making connection   
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM user_info WHERE account='" + textBox1.Text + "' AND password='" + textBox2.Text + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form4 form4 = new Form4();
                form4.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Invalid username or password");


        }
    }
}

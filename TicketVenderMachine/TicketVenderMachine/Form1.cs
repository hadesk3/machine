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
    public partial class Form1 : Form
    {
        SqlConnection cn;
        SqlDataAdapter data;
        SqlCommand cm;
        DataTable tb;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2= new Form2();
         //   this.Hide();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
          //  this.Hide();
            form3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string con = "Data Source=localhost\\sqlexpress;Initial Catalog=machine;Integrated Security=True";
            cn = new SqlConnection(con);
            cn.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

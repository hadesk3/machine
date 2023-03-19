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
    public partial class Form2 : Form
    {
        SqlConnection cn;
        SqlDataAdapter data;
        SqlCommand cm;
        DataTable tb;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" )
            {
                var sql = "insert into register values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                data = new SqlDataAdapter(sql, cn);
                tb = new DataTable();
                data.Fill(tb);

                var sql2 = "insert into user_info values ('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                data = new SqlDataAdapter(sql2, cn);
                tb = new DataTable();
                data.Fill(tb);
                this.Hide();

            }    
            else
            {
                MessageBox.Show("please fill full data");
            }    
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            string con = "Data Source=localhost\\sqlexpress;Initial Catalog=machine;Integrated Security=True";
            cn = new SqlConnection(con);
            cn.Open();
        }
    }
}

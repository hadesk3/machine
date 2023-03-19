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
    public partial class Form4 : Form
    {
        SqlConnection cn;
        SqlDataAdapter data;
        SqlCommand cm;
        DataTable tb;
        String text1 = "";
        String text2 = "";
       
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected= true;
                text1 = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                text2 = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();

                button1.Enabled = false;
              
                
            }    
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string con = "Data Source=localhost\\sqlexpress;Initial Catalog=machine;Integrated Security=True";
            cn = new SqlConnection(con);
            cn.Open();
            string sql = "select * from destination ";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            dataGridView1.DataSource = tb;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=machine;Integrated Security=True"); // making connection   
           



            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM register WHERE id='" + textBox4.Text + "'",con);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);


            if (dt.Rows[0][0].ToString() == "1")
            {
                if (textBox4.Text != "")
                {

                    var sql1 = "insert into ticket values ('" + textBox4.Text + "','" + text2 + "','" + textBox1.Text + "')";
                    data = new SqlDataAdapter(sql1, cn);
                    tb = new DataTable();
                    data.Fill(tb);
                    MessageBox.Show("sucess");
                    text1 = "";
                    text2 = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    button1.Enabled = false;

                }

            }
            else
                MessageBox.Show("Invalid id");


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && text1 != "")
            {
                var data = Int32.Parse(textBox1.Text) * Int32.Parse(text1);
                textBox2.Text = data.ToString();
                button1.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked) 
            {
                pictureBox1.Visible = true; 
                textBox3.Enabled= false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox3.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

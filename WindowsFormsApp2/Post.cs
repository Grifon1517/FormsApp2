using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Post : Form
    {
        OleDbDataAdapter da;
        DataSet ds;
        OleDbConnection con;
        OleDbCommand cmd;
        public Post()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cat.accdb");
        }

        private void Post_Load(object sender, EventArgs e)
        {
            Dann();
        }
        void Dann()
        {
            da = new OleDbDataAdapter("SELECT * FROM Поставщик", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Поставщик");
            dataGridView1.DataSource = ds.Tables["Поставщик"];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Insert into Поставщик (Название,Телефон,Адрес) VALUES (@name,@tel,@adres)";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox3.Text);
            if (textBox4.Text.ToString().StartsWith("071") && textBox4.Text.ToString().Length == 10)
            {
                cmd.Parameters.AddWithValue("@tel", textBox4.Text);
            }
            cmd.Parameters.AddWithValue("@adres", textBox5.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Dann();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Delete From Поставщик Where Код=@kodd";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@kodd", dataGridView1.CurrentRow.Cells[0].Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Dann();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }



        }
    }
}

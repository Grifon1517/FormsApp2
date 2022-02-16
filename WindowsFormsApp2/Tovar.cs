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
    public partial class Tovar : Form
    {
        OleDbDataAdapter da;
        DataSet ds;
        OleDbConnection con;
        OleDbCommand cmd;
        public Tovar()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=cat.accdb");
        }

        public static int cena, kol;
        public DateTime d = new DateTime();
        public string b;


        void Dann()
        {
            da = new OleDbDataAdapter("SELECT * FROM Товар", con);
            ds = new DataSet();           
            con.Open();
            da.Fill(ds, "Товар");
            dataGridView1.DataSource = ds.Tables["Товар"];
            con.Close();
            
        } 

        private void Tovar_Load(object sender, EventArgs e)
        {
            Dann();
            con.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "Select Название From Поставщик";
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Название"].ToString());
            }
            

            con.Close();
            Dann();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            string query = "Insert into Товар (Название,Описание,Количество,Цена,Срок_годности,Поставщик) VALUES (@name,@opis,@kol,@cena,@sg,@post)";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@opis", textBox2.Text);
            cmd.Parameters.AddWithValue("@kol", textBox3.Text);
            cmd.Parameters.AddWithValue("@cena", textBox4.Text);
            cmd.Parameters.AddWithValue("@sg", textBox5.Text);
            cmd.Parameters.AddWithValue("@post", comboBox1.Text);
            cena = int.Parse(textBox4.Text);
            kol = int.Parse(textBox3.Text);
            d = DateTime.Parse(textBox5.Text);
            con.Open();
            cmd.ExecuteNonQuery();          
            con.Close();
            Dann();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Delete From Товар Where Код=@kod";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@kod", dataGridView1.CurrentRow.Cells[0].Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Dann();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void button3_Click(object sender, EventArgs e)
        {
            
            
            if ((d - DateTime.Today).TotalDays == 7)
            {
                OleDbCommand da = new OleDbCommand("SELECT * FROM Срок_годности");
            }
            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

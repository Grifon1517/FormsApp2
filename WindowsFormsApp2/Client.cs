using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Client : Form
    {
        OleDbDataAdapter da;
        DataSet ds;
        OleDbConnection con;
        OleDbCommand cmd;
        
        public Client()
        {

            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cat.accdb");
           
        }

       
        void Dann()
        {
            da = new OleDbDataAdapter("SELECT * FROM Покупатель", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Покупатель");
            dataGridView1.DataSource = ds.Tables["Покупатель"];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Client_Load(object sender, EventArgs e)
        {
            Dann();
            con.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "Select Название From Товар";
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Название"].ToString());
            }
            con.Close();
            Dann();
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            string query = "Insert into Покупатель (ФИО,Адрес,Телефон,ЗаказанныеТовары,КоличествоТовара,СуммаПокупки) VALUES (@fio,@adres,@tel,@nt,@kolt,@sum)";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@fio", textBox1.Text);
            cmd.Parameters.AddWithValue("@adres", textBox2.Text);
                    
            if (textBox3.Text.ToString().StartsWith("071")&& textBox3.Text.ToString().Length==10)
            {
                cmd.Parameters.AddWithValue("@tel", textBox3.Text);
            }

            cmd.Parameters.AddWithValue("@nt", comboBox1.Text);
            cmd.Parameters.AddWithValue("@kolt", textBox4.Text);
            Tovar tovar = new Tovar();
            int b = int.Parse(textBox4.Text);
            int cena = Tovar.cena * b;
            textBox5.Text = cena.ToString();
            cmd.Parameters.AddWithValue("@sum", textBox5.Text);
            
            

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Dann(); 
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Delete From Покупатель Where Номер=@nomz";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@nomz", dataGridView1.CurrentRow.Cells[0].Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Dann();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox_PressKey(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   
            Tovar tovar = new Tovar();
            int a = Convert.ToInt32(tovar.textBox4.Text);
            int b = Convert.ToInt32(textBox4.Text);
            int cena = a * b;
            textBox5.Text = cena.ToString();
            cmd.Parameters.AddWithValue("@sum", textBox5.Text);

        }
    }
}

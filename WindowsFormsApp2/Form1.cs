using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tovar tovar = new Tovar();
            tovar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Post post = new Post();
            post.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

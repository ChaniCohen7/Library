using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dal;


namespace Gui
{
     
    public partial class Form1 : Form
    {
        bl db = new bl();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void send_Click(object sender, EventArgs e)
        {
            book b = new book()
            {
                id=int.Parse(textBox1.Text),
                name=textBox2.Text,
                writer_name=textBox3.Text,
                publish_year = int.Parse(textBox4.Text)

            };
            db.AddBook(b);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.BooksList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ShowOneBook(int.Parse(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.SetOneBook(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, int.Parse( textBox4.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.BorrowsBook();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!db.IsBookBorrowed(int.Parse(textBox3.Text)))
                db.Borrow(int.Parse(textBox1.Text), textBox2.Text, int.Parse(textBox3.Text));

                

            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = db.ShowPopular().ToString();

        }
    }
}

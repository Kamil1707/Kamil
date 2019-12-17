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


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 reg = new Form2();
            reg.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=auth.mdb");
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("Select Count(*)From auth where Login='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", connect);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form3 suc = new Form3();
                suc.Show();
                this.Hide();
            }
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");

            }
            else
            {
                MessageBox.Show("Неправильно введеные имя или пароль");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

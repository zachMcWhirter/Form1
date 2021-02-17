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

namespace Form1
{
    
    public partial class Form1 : Form
    {
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source = BIG-RICK\SQLEXPRESS; 
                                            Initial Catalog = StudentInformation;
                                            Integrated Security = True");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Display();
        }

        public void Display()
        {
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("Select * from StudentDetails", connection);
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd;
            connection.Open();
            String sqlQuery = "INSERT INTO StudentDetails (Name,Age,City,Gender) VALUES (@Name,@Age,@City,@Gender)";

            cmd = new SqlCommand(sqlQuery, connection);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@city", textBox3.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            Display();
            MessageBox.Show("Data Inserted ");
        }

        public void CLearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Items.Clear();
        }























        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

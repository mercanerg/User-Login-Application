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


namespace EMPLOYER
{
    
    public partial class Form4 : Form
    {
          SqlConnection conn = new SqlConnection("Data Source=MERCAN \\SQLSERVER;Initial Catalog=DATAMER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
               
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dATAMERDataSet.PERSONEL' table. You can move, or remove it, as needed.
            this.pERSONELTableAdapter.Fill(this.dATAMERDataSet.PERSONEL);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into PERSONEL (NAME, EMAIL, DEPARTMENT, PHONE, SALARY, ADRES) VALUES(@name, @email, @department, @phone, @salary, @adres)", conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@email", textBox2.Text);
            cmd.Parameters.AddWithValue("@department", comboBox1.Text);
            cmd.Parameters.AddWithValue("@phone", textBox4.Text);
            float salary = float.Parse(textBox3.Text);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@adres", textBox6.Text);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            } 
            cmd.ExecuteNonQuery();
            
            conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}

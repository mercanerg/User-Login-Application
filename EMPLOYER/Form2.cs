using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMPLOYER
{
    public partial class Form2 : Form
    {
        public string user;
        public string statu;
        SqlConnection conn = new SqlConnection("Data Source=MERCAN \\SQLSERVER;Initial Catalog=DATAMER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (statu.Trim()=="USER")
            {
                menuStrip1.Hide();
               button1.Hide();
                this.Size = new Size(400,320);
                cmd = new SqlCommand("select [NAME],[EMAIL],[DEPARTMENT] from PERSONEL ", conn);
            }
           else if(statu.Trim()=="ADMIN")
            {
                menuStrip1.Show();
                button1.Show();
                this.Size = new Size(1150, 320);
                this.StartPosition = FormStartPosition.CenterScreen;    
                cmd = new SqlCommand("select * from PERSONEL ", conn);
            }
            
            label1.Text = "Welcome to RCN System " + user.Trim();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            
                       
        }

       
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void employersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

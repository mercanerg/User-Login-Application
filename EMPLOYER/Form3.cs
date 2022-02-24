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
    public partial class Form3 : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=MERCAN \\SQLSERVER;Initial Catalog=DATAMER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from LogTable ", conn);
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
    }
}

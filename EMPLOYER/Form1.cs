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
using System.Net;

namespace EMPLOYER
{
    public partial class frmLogin : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=MERCAN \\SQLSERVER;Initial Catalog=DATAMER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        public frmLogin()
        { 
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName();
            string userIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            DateTime tarih = DateTime.Now;
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblLogin where userName='" + txtUser.Text + "' and parola='" + txtpsw.Text + "'", conn);
            
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                string userName = dr[1].ToString();
                string yetki=dr[3].ToString();
                dr.Close();
                userName= userName.Trim(); 
                yetki= yetki.Trim();
                SqlCommand komut = new SqlCommand("INSERT INTO LogTable (userName, yetki,IPNumber,zaman, host) VALUES(@userName, @yetki,@userIP,@tarih, @hostName); ",conn);
                komut.Parameters.AddWithValue("@userName", userName);
                komut.Parameters.AddWithValue("@yetki", yetki);
                komut.Parameters.AddWithValue("@userIP", userIP);
                komut.Parameters.AddWithValue("@tarih", tarih);
                komut.Parameters.AddWithValue("@hostName", hostName);
                SqlDataReader drLog = komut.ExecuteReader(); 
                Form2 frm = new Form2();
                frm.user = userName;
                frm.statu = yetki;
                
                this.Hide();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Invalid User Name or Password, try again","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUser.Text = "";
                txtpsw.Text = "";
            }
            conn.Close();
        }
    }
}

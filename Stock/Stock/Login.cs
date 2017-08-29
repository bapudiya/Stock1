using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //TO-DO: Checked Login UserName & Password
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Stock1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                FROM [Stock1].[dbo].[Login] Where UserName='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid UserName & Password..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClear_Click(sender, e);
            }
        }

    }
}
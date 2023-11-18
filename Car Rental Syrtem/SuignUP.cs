using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace creat_car_rental_system
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = dbConnection.GetSqlConnection())
            {
                if (txtname.Text != "" && txtuname.Text != "" && txtmobile.Text != "" && txtaddress.Text != "" && txtpass.Text != "" && txtconpass.Text != "" && txtpass.Text == txtconpass.Text)
                {
                    SqlCommand cmd = new SqlCommand("insert into customer (cusname,username,mobile,address,pass) values('" + txtname.Text + "'," +
                   "'" + txtuname.Text + "', '" + txtmobile.Text + "','" + txtaddress.Text + "','" + txtconpass.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successfully.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                    login obj = new login();
                    
                    this.Hide();
                    obj.Show();

                }
                else
                {
                    MessageBox.Show("No Info entered.", "Error" + MessageBoxButtons.OK + MessageBoxIcon.Warning);
                }

            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (txt_usern.Text == "")
            {
                MessageBox.Show("Username Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txt_userpassword.Text == "")
            {
                MessageBox.Show("Password Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlConnection con = dbConnection.GetSqlConnection();

                SqlCommand cmd = new SqlCommand("Select * from customer where username='" + txt_usern.Text + "' and Pass ='" + txt_userpassword.Text + "' ", con);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    int cusid = Convert.ToInt32(dt.Rows[0]["cusid"]);
                    Dashboard dashboard = new Dashboard(cusid);
                    this.Hide();
                    dashboard.Show();
                    
                }

                else
                {
                    MessageBox.Show("Wrong Username OR Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signup reg= new signup();
            this.Hide();
            reg.Show();
        }
    }
}

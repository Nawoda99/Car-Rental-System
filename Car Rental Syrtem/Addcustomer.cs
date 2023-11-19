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

namespace creat_car_rental_system
{
    public partial class Addcustomer : Form
    {
        public Addcustomer()
        {
            InitializeComponent();
        }

        private void btn_sve_Click(object sender, EventArgs e)
        {
            SqlConnection con = dbConnection.GetSqlConnection();
            {
                if (txtname.Text != "" && txtmobile.Text != "" && txtaddress.Text != "" )
                {
                    SqlCommand cmd = new SqlCommand("insert into Customer (cusname,username,mobile,address) values('" + txtname.Text + "','" + txt_usrname.Text + "', '" + txtmobile.Text + "','" + txtaddress.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                    
                    ManageCustomer manageCustomer = new ManageCustomer();
                    this.Hide();
                    manageCustomer.Show();



                }
                else
                {
                    MessageBox.Show("No Info entered.", "Error" + MessageBoxButtons.OK + MessageBoxIcon.Warning);
                }

            }
        }
    }
}

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
    public partial class addCars : Form
    {
        public addCars()
        {
            InitializeComponent();
        }

        private void btn_sve_Click(object sender, EventArgs e)
        {
            SqlConnection con = dbConnection.GetSqlConnection();
            {
                if (txt_name.Text != "" && txt_model.Text != "" && txt_price.Text != "" && txt_status.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into car (carname,model,status,price) values('" + txt_name.Text + "', '" + txt_model.Text + "','" + txt_status.Text + "','" + txt_price.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Added.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);

                    ManageCars manageCars = new ManageCars();
                    this.Hide();
                    manageCars.Show();



                }
                else
                {
                    MessageBox.Show("No Info entered.", "Error" + MessageBoxButtons.OK + MessageBoxIcon.Warning);
                }
            }
        }
    }
}

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

namespace creat_car_rental_system
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
        }

        private void LoadDataIntoComboBox()
        {
            


            SqlConnection con = dbConnection.GetSqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT carname FROM car ", con);

            con.Open();

            try
            {
                        

                        
                        SqlDataReader reader = cmd.ExecuteReader();

                        
                        cmb_car.Items.Clear();

                        
                        while (reader.Read())
                        {
                            
                            cmb_car.Items.Add(reader["carname"].ToString());
                        }

                       
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show("Error: " + ex.Message);
                    }
             
        }

            

            private void btn_logout_Click(object sender, EventArgs e)
        {
            login log = new login();
            this.Hide();
            log.Show();
        }

        private void cmb_car_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_car.SelectedIndex != -1)
            {
                SqlConnection con = dbConnection.GetSqlConnection();

                SqlCommand cmd = new SqlCommand("SELECT model, status,price  FROM car WHERE carname = '" + cmb_car.SelectedItem.ToString() + "'", con);

                con.Open();

                try
                {






                    SqlDataReader detailsReader = cmd.ExecuteReader();


                    if (detailsReader.Read())
                    {

                        label1.Text = detailsReader["model"].ToString();
                        label2.Text = detailsReader["status"].ToString();
                        label3.Text = detailsReader["price"].ToString();
                    }


                    // detailsReader.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message);
                }

            }

        }
    }
}

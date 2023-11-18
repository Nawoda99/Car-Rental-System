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
using System.Diagnostics;

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

                        lbl_model.Text = detailsReader["model"].ToString();
                        lbl_status.Text = detailsReader["status"].ToString();
                        lbl_price.Text = detailsReader["price"].ToString();
                    }


                     detailsReader.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message);
                }

            }

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = dbConnection.GetSqlConnection();
         
            int carid = 1;
            int cusid = 1;
            
            SqlCommand cmd = new SqlCommand("insert into customer_book_car(bookedDate,promisedDate,status,price,carid,cusid,totalAmount) values( '" + date_rent.Value.ToString("d") + "', '" + date_promised.Value.ToString("d") + "','" + lbl_status.Text + "','" + lbl_price.Text + "','" + carid + "','" + cusid + "','" + lbl_amount.Text + "') ", con); ;
            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Registration Successfully.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);

            


        }

        private void date_promised_ValueChanged(object sender, EventArgs e)
        {
            DateTime rent = date_rent.Value;
            DateTime promised = date_promised.Value;

           
            int dayDifference = (int)(promised - rent).TotalDays;

            if (int.TryParse(lbl_price.Text, out int price))
            {
                
                int totalAmount = dayDifference * price;

                
                lbl_amount.Text = totalAmount.ToString();
            }
            else
            {
                
                MessageBox.Show("Invalid price format. Please enter a valid numeric value.");
            }

        }
    }
}

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
    public partial class adminbooking : Form
    {
        private int cusId;
        private int carId;
        public adminbooking()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
            LoadDataIntoCarComboBox();



        }


        private void LoadDataIntoComboBox()
        {



            SqlConnection con = dbConnection.GetSqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT cusname,cusid FROM customer", con);

            con.Open();

            try
            {



                SqlDataReader reader = cmd.ExecuteReader();


                cmb_cusname.Items.Clear();


                while (reader.Read())
                {

                    cmb_cusname.Items.Add(reader["cusname"].ToString());
                    cusId = Convert.ToInt32(reader["cusid"]);
                }


                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void LoadDataIntoCarComboBox()
        {



            SqlConnection con = dbConnection.GetSqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT carname,carid FROM car ", con);

            con.Open();

            try
            {



                SqlDataReader reader = cmd.ExecuteReader();


                cmb_car.Items.Clear();


                while (reader.Read())
                {

                    cmb_car.Items.Add(reader["carname"].ToString());
                    carId = Convert.ToInt32(reader["carid"]);
                }


                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string booked = "Booked";
            SqlConnection con = dbConnection.GetSqlConnection();
            if (lbl_status.Text == "Booked")
            {
                MessageBox.Show("This Car Already Booked", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);
            }

            else
            {
                SqlCommand cmd = new SqlCommand("insert into customer_book_car(bookedDate,promisedDate,status,amount,carid,cusid) values( '" + date_rent.Value.ToString("d") + "', '" + date_promised.Value.ToString("d") + "','" + lbl_status.Text + "','" + lbl_amount.Text + "','" + carId + "','" + cusId + "') ", con); ;

                SqlCommand cmnd = new SqlCommand("Update car SET status = '" + booked + "' WHERE carid='" + carId + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                cmnd.ExecuteNonQuery();

                MessageBox.Show("Registration Successfully.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);

            }


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

        private void cmb_car_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_amount.Text = "";
            if (cmb_car.SelectedIndex != -1)
            {
                SqlConnection con = dbConnection.GetSqlConnection();

                SqlCommand cmd = new SqlCommand("SELECT carid, model, status,price  FROM car WHERE carname = '" + cmb_car.SelectedItem.ToString() + "'", con);

                con.Open();

                try
                {






                    SqlDataReader detailsReader = cmd.ExecuteReader();


                    if (detailsReader.Read())
                    {
                        carId = Convert.ToInt32(detailsReader["carid"]);
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

        private void btn_back_Click(object sender, EventArgs e)
        {
            adminDashboard adminDashboard = new adminDashboard();
            this.Hide();
            adminDashboard.Show();
        }
    }
}

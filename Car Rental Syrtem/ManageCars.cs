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
    public partial class ManageCars : Form
    {
        public ManageCars()
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


                cmb_carname.Items.Clear();


                while (reader.Read())
                {

                    cmb_carname.Items.Add(reader["carname"].ToString());
                }


                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmb_carname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_carname.SelectedIndex != -1)
            {
                SqlConnection con = dbConnection.GetSqlConnection();

                SqlCommand cmd = new SqlCommand("SELECT carid,carname,model,status,price FROM car WHERE carname = '" + cmb_carname.SelectedItem.ToString() + "'", con);

                con.Open();

                try
                {






                    SqlDataReader detailsReader = cmd.ExecuteReader();


                    if (detailsReader.Read())
                    {
                        lblid.Text = detailsReader["carid"].ToString();
                        txt_name.Text = detailsReader["carname"].ToString();
                        txt_model.Text = detailsReader["model"].ToString();
                        txt_price.Text = detailsReader["price"].ToString();
                        txt_status.Text = detailsReader["status"].ToString();
                       
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

            if (txt_model.Text != "" && txt_price.Text != "" && txt_status.Text != "" )
            {
                SqlCommand cmd = new SqlCommand("Update car SET carname = '" + txt_name.Text + "', model = '" + txt_model.Text + "' ,status = '" + txt_status.Text + "' ,price = '" + txt_price.Text + "' WHERE carid = '" + int.Parse(lblid.Text) + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Car update Successfully.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);





            }
            else
            {
                MessageBox.Show("No Info entered.", "Error" + MessageBoxButtons.OK + MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           adminDashboard adminDashboard = new adminDashboard();
            this.Hide();
            adminDashboard.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmb_carname.SelectedItem = null;
            txt_name.Clear();
            lblid.Text = "";
            txt_model.Clear();
            txt_price.Clear();
            txt_status.Clear();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addCars addCars = new addCars();
            this.Hide();
            addCars.Show();
        }
    }
}

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
    public partial class ManageCustomer : Form
    {
        public ManageCustomer()
        {
            InitializeComponent();
            LoadDataIntoComboBox();
        }

        private void LoadDataIntoComboBox()
        {



            SqlConnection con = dbConnection.GetSqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT cusid FROM customer ", con);

            con.Open();

            try
            {



                SqlDataReader reader = cmd.ExecuteReader();


                cmb_cusid.Items.Clear();


                while (reader.Read())
                {

                    cmb_cusid.Items.Add(reader["cusid"].ToString());
                }


                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void cmb_cusid_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_cusid.SelectedIndex != -1)
            {
                SqlConnection con = dbConnection.GetSqlConnection();

                SqlCommand cmd = new SqlCommand("SELECT cusname,username,mobile,address FROM customer WHERE cusid = '" + cmb_cusid.SelectedItem.ToString() + "'", con);

                con.Open();

                try
                {






                    SqlDataReader detailsReader = cmd.ExecuteReader();


                    if (detailsReader.Read())
                    {

                        txt_name.Text = detailsReader["cusname"].ToString();
                        txt_usrname.Text = detailsReader["username"].ToString();
                        txt_mobile.Text = detailsReader["mobile"].ToString();
                       txt_address.Text = detailsReader["address"].ToString();
                    }


                    detailsReader.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addcustomer addcustomer = new Addcustomer();
            this.Hide();
            addcustomer.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = dbConnection.GetSqlConnection();

            if (txt_name.Text != "" && txt_usrname.Text != "" && txt_mobile.Text != "" && txt_address.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Update customer SET cusname = '" + txt_name.Text + "' ,username = '" + txt_usrname.Text + "' ,mobile = '" + txt_mobile.Text + "' ,address = '" + txt_address.Text + "' WHERE cusid = '" + Convert.ToInt32(cmb_cusid.SelectedItem) + "'  ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer update Successfully.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                
                

                

            }
            else
            {
                MessageBox.Show("No Info entered.", "Error" + MessageBoxButtons.OK + MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmb_cusid.SelectedItem = null;
            txt_name.Clear();
            txt_usrname.Clear();
            txt_mobile.Clear();
            txt_address.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = dbConnection.GetSqlConnection();

            if (txt_name.Text != "" && txt_usrname.Text != "" && txt_mobile.Text != "" && txt_address.Text != "")
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE cusid = '"+ Convert.ToInt32(cmb_cusid.SelectedItem) + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer update Successfully.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);





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
    }
}

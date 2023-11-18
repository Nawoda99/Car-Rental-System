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
    }
}

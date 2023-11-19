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
    public partial class adminDashboard : Form
    {
        public adminDashboard()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {


            SqlConnection con = dbConnection.GetSqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM customer_book_car", con);

            con.Open();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);


                dgv_cus.DataSource = dataTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer();
            this.Hide();
            manageCustomer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageCars manageCars = new ManageCars();
            this.Hide();
            manageCars.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login log = new login();
            this.Hide();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminbooking adminbooking = new adminbooking();
            this.Hide();
            adminbooking.Show();
        }
    }
}

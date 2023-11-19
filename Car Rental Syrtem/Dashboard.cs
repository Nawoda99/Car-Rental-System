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
    public partial class Dashboard : Form
    {
        private int id;
        public Dashboard(int id)
        {
            InitializeComponent();
            this.id = id;
            getName(id);
            LoadDataIntoDataGridView();

        }

       

        public void getName(int id)
        {
            SqlConnection con = dbConnection.GetSqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT cusname FROM customer WHERE cusid = '"+id+"' ", con);

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {

                lbl_name.Text = dt.Rows[0]["cusname"].ToString();
            }
         
            

        }

        private void LoadDataIntoDataGridView()
        {
            
           
            SqlConnection con = dbConnection.GetSqlConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM booking_details ", con);

            con.Open();

            try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        
                        dgv_booked.DataSource = dataTable;
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

        private void btn_booking_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking(id);

            this.Hide();
            booking.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creat_car_rental_system
{
    internal class dbConnection
    {
        private static SqlConnection conn;

        public static SqlConnection GetSqlConnection()
        {
            conn = new SqlConnection("Data Source=PC01-30;Initial Catalog=carRental;Integrated Security=True");
            return conn;
        }

    }
}

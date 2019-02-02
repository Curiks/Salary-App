using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SalaryLibrary
{
    public static class DbConnection
    {
        public static string conString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(conString);
        }

        public static bool IsAvailable(this SqlConnection conString)
        {
            try
            {
                conString.Open();
                conString.Close();
            }
            catch (SqlException)
            {
                return false;
                throw;
            }

            return true;
        }
    }
}

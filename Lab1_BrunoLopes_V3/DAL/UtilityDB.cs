using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1_BrunoLopes_V3.DAL
{
    public class UtilityDB
    {

        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn.Open();
            return conn;
        }

    }
}
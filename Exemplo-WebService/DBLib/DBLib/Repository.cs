using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DBLib
{
    public class Repository
    {
        
        private static string connectionString = @"Data Source=G:\renato\Exemplo\DBLib\DBLib\BancoLocal.sdf";

        public static  SqlConnection GetConnection()
        {                         
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static LoginDB Login { get; set; }

       
    }
}

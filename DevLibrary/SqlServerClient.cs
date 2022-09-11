using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary
{
    internal class SqlServerClient
    {
        //first install package: Install-Package Microsoft.Data.SqlClient -Version 4.8.3 
        //becarefull about the version
        public static string connectionString = "";
        public static SqlConnection con;
        public static void CreateTheConnection()
        {
            connectionString = "Data Source=PC00D861E8ADE6;Initial Catalog=dbLaender;Persist Security Info=True;User ID=sa;Password=Admin2019$";

            // Fehler Abfangen
            // try TAB TAB

            try
            {
                con = new SqlConnection(connectionString);
                con.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

        public static int Delete(string sql)
        {           
            SqlCommand cmd = new SqlCommand(sql, con);
            int num = cmd.ExecuteNonQuery();
            return num;
        }
        private static int Update(string sql)
        {           
            SqlCommand cmd = new SqlCommand(sql, con);
            int num = cmd.ExecuteNonQuery();
            return num;
        }
        private static int Create(string sql)
        {            
            SqlCommand cmd = new SqlCommand(sql, con);
            int num = cmd.ExecuteNonQuery();
            return num;
        }
        private static string Search(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = Convert.ToInt32(rdr["Id"]);
                string country = rdr["Country"].ToString();
                bool active = Convert.ToBoolean(rdr["Active"]);
                return id + ";" + country + ";" + active;
            }
            return null;
        }
        private static string ReadData(string sql)
        {

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                int id = Convert.ToInt32(rdr["Id"]);
                string country = rdr["Country"].ToString();
                bool active = Convert.ToBoolean(rdr["Active"]);
                return id + ";" + country + ";" + active;
            }
            return null;

        }
        private static string ReadAllDatas(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                int id = Convert.ToInt32(rdr["Id"]);
                string country = rdr["Country"].ToString();
                bool active = Convert.ToBoolean(rdr["Active"]);
                return id + ";" + country + ";" + active;
            }
            return null;
        }
    }
}

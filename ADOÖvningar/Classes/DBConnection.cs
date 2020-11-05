using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADOÖvningar.Classes
{
    public static class DBConnection
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static string connectionstring =
            ConfigurationManager.ConnectionStrings["DB_Assignment"].ConnectionString;


        public static int ExecuteScalarSP(string commandString, List<SqlParameter> parameters)
        {
            try
            {
                using (conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    cmd = new SqlCommand(commandString, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    object returnvalue = cmd.ExecuteScalar();

                    if (returnvalue != null)
                    {
                        return (int)returnvalue;
                    }
                }    
            }
            catch (Exception)
            {
                MessageBox.Show("Faulty connection to database. Try again");
            }

            return 0;
        }

        public static void ExecuteNonQuery(string commandString, List<SqlParameter> parameters)
        {
            try
            {
                using (conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    cmd = new SqlCommand(commandString, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Faulty connection to database. Try again");
            }
        }

        public static DataTable GetAds(string commandString, List<SqlParameter> parameters)
        {
            DataTable table = new DataTable();
            try
            {
                using (conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    cmd = new SqlCommand(commandString, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        table.Columns.Add("Title");
                        table.Columns.Add("Description");
                        table.Columns.Add("Type");
                        table.Columns.Add("Image");
                        table.Columns.Add("User");

                        while (reader.Read())
                        {
                            DataRow row = table.NewRow();

                            row["Title"] = reader["AdvertTitle"];
                            row["Description"] = reader["Description"];
                            row["Type"] = reader["AdvertType"];
                            row["Image"] = reader["AdImage"];
                            row["User"] = reader["User"];
                            table.Rows.Add(row);

                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Faulty connection to database. Try again");
            }

            return table;
        }

    }
}

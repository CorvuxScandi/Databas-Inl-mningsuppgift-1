using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ADOÖvningar.Classes
{
    public static class DBConnection
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static string connectionstring =
            ConfigurationManager.ConnectionStrings["DB_Assignment"].ConnectionString;


        public static string FindSingleValue(string command, SqlParameter param)
        {
            try
            {
                using (conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    cmd = new SqlCommand(command, conn);

                    cmd.Parameters.Add(param);

                    object returnvalue = cmd.ExecuteScalar();

                    if (returnvalue != null)
                    {
                        return returnvalue.ToString();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Faulty connection to database. Try again");
                return "";
            }

            return "";
        }

        public static void ExecuteNonQuery(string commandString, List<SqlParameter> parameters)
        {
            try
            {
                using (conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    cmd = new SqlCommand(commandString, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

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

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.Fill(table);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Faulty connection to database. Try again");
            }

            return table;
        } 

        public static DataTable TableFromDataBase(string commandstring)
        {
            using (conn = new SqlConnection(connectionstring))
            {
                DataTable table = new DataTable();
                conn.Open();
                cmd = new SqlCommand(commandstring, conn);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(table);
                }


                return table;
            }

        }

    }
}

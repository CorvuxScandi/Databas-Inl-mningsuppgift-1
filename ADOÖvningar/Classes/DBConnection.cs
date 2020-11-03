using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADOÖvningar.Classes
{
    public class DBConnection
    {
        public void MakeConnetion(string commandString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(commandString, con);
                    con.Open();
                    cmd.ExecuteReader();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Faulty connection to database. Try again");
            }
            
        }


    }
}

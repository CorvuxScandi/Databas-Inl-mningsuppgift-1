using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOÖvningar.Classes
{
    public class UserRepo
    {
        private List<SqlParameter> parameters;

        public void RegristerUser(string userName, string password)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", userName));
            parameters.Add(new SqlParameter("@password", password));

            DBConnection.ExecuteNonQuery("CreateNewUser", parameters);

        }

        public int FindUser(string userName, string password)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", userName));
            parameters.Add(new SqlParameter("@userpassword", password));

            return DBConnection.ExecuteScalarSP("FindUser", parameters);
        }

    }
}

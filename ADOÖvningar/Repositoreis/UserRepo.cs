using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADOÖvningar.Classes
{
    public static class UserRepo
    {
        private static List<SqlParameter> parameters;


        public static void RegristerNewUser(string userName, string password)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", userName));
            parameters.Add(new SqlParameter("@password", password));

            DBConnection.ExecuteNonQuery("CreateUser", parameters);

        }

        public static string[] FindUser(string userName)
        {
            string[] lookup = new string[]
            {
             DBConnection.FindSingleValue("Select Username from AdvertUser where @username = username", new SqlParameter("@username", userName)),
             DBConnection.FindSingleValue("Select Password from AdvertUser where @username = username", new SqlParameter("@username", userName)),
             DBConnection.FindSingleValue("Select UserID from AdvertUser where @username = username", new SqlParameter("@username", userName)).ToString()
            };

            return lookup;
        }

        public static int UserLogin(string username, string password)
        {
            string[] dbValues = FindUser(username);

            if (dbValues[0] == username && dbValues[1] == password)
            {
                return int.Parse(dbValues[2]);
            }

            return 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOÖvningar.Classes
{
    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserID { get; set; }

        public User(string userName, string password, int userID)
        {
            UserName = userName;
            Password = password;
            UserID = userID;


        }
    }
}

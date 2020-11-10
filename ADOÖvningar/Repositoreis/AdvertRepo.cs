using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ADOÖvningar.Classes
{
    public static class AdvertRepo
    {
        private static List<SqlParameter> parameters;


        public static DataTable GetAllAds()
        {
            return DBConnection.TableFromDataBase("GetAllAds");
        }



        public static void NewAd(string title, string description, int typeID, string imagePath, int userID)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@title", title));
            parameters.Add(new SqlParameter("@description", description));
            parameters.Add(new SqlParameter("@typeID", typeID));
            parameters.Add(new SqlParameter("@imagePath", imagePath));
            parameters.Add(new SqlParameter("@userID", userID));

            DBConnection.ExecuteNonQuery("CreateNewAd", parameters);

        }

        public static void DeleteAd(int adID)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AdvertID", adID));

            DBConnection.ExecuteNonQuery("DeleteAD", parameters);

        }



    }
}

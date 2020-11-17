using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADOÖvningar.Classes
{
    public static class AdvertRepo
    {
        private static List<SqlParameter> parameters;

        public static DataTable GetAllAds()
        {
            return DBConnection.TableFromDataBase("GetAllAds");
        }

        public static void NewAd(string title, string description, float price, int typeID, int userID) //string imagePath,
        {
            parameters = new List<SqlParameter>
            {
                new SqlParameter("@title", title),
                new SqlParameter("@description", description),
                new SqlParameter("@CategoryID", typeID),
                new SqlParameter("@userID", userID),
                new SqlParameter("@dateAdded", DateTime.Now.ToShortDateString()),
                new SqlParameter("@price", price)
            };

            DBConnection.ExecuteNonQuery("makeAd", parameters);

        }

        public static void DeleteAd(int adID)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AdID", adID));

            DBConnection.ExecuteNonQuery("RemoveAD", parameters);

        }

        public static void EditAd(DataRow selectedRow, int user)
        {
            MakeNewAd edit = new MakeNewAd(
                Convert.ToInt32(selectedRow["AdID"]),
                selectedRow["AdTitel"].ToString(),
                float.Parse(selectedRow["AdPrice"].ToString()),
                selectedRow["AdDescription"].ToString(),
                selectedRow["AdCategory"],
                user);

            edit.Show();
        }

    }
}

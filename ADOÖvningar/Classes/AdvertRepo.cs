using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ADOÖvningar.Classes
{
    public class AdvertRepo
    {
        private List<SqlParameter> parameters;

        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public object ImagePath { get; set; }
        public string UserName { get; set; }

        public AdvertRepo()
        {
                
        }
        //public AdvertRepo(string title, string description, int typeID, string imagePath, int userID)
        //{
        //    Title = title;
        //    Description = description;
        //    TypeID = typeID;
        //    ImagePath = imagePath;
        //    UserID = userID;
        //}

        public int NewAd(string title, string description, int typeID, string imagePath, int userID)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@title", title));
            parameters.Add(new SqlParameter("@description", description));
            parameters.Add(new SqlParameter("@typeID", typeID));
            parameters.Add(new SqlParameter("@imagePath", imagePath));
            parameters.Add(new SqlParameter("@userID", userID));

            return DBConnection.ExecuteScalarSP("CreateNewAd", parameters);

        }

        public void DeleteAd(int adID)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AdvertID", adID));

            DBConnection.ExecuteNonQuery("DeleteAD", parameters);

        }

        

    }
}

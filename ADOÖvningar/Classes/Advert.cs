using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOÖvningar.Classes
{
    public class Advert
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public object ImagePath { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }

        public Advert()
        {

        }

        public Advert(string title, string description, string typeID, string imagePath, int userID)
        {
            Title = title;
            Description = description;
            Category = typeID;
            ImagePath = imagePath;
            UserID = userID;
        }

    }
}

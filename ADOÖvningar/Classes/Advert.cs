using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOÖvningar.Classes
{
    public class Advert
    {
        public string AdTitle { get; set; }

        public int AdID { get; set; }

        public AdvertType AdvertType { get; set; }

        public string Description { get; set; }

        public Advert(string adTitle, int adID, AdvertType advertType, string description)
        {
            AdTitle = adTitle;

            AdID = adID;

            AdvertType = advertType;

            Description = description;
        }

    }
}

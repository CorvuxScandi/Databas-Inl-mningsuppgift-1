using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOÖvningar.Classes
{
    public class AdvertType
    {
        public string TypeName { get; set; }

        public int AdvertTypeID { get; set; }

        public AdvertType(string typeName, int advertTypeID)
        {
            TypeName = typeName;

            AdvertTypeID = advertTypeID;


        }

    }
}

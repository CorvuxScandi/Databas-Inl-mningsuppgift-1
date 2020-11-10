using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOÖvningar.Classes
{
    public class Category
    {
        public string TypeName { get; set; }

        public int AdvertTypeID { get; set; }

        public Category()
        {

        }
        public Category(string typeName, int advertTypeID)
        {
            TypeName = typeName;

            AdvertTypeID = advertTypeID;


        }
       
    }
}

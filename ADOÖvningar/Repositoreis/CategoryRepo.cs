using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOÖvningar.Classes
{
    public static class CategoryRepo
    {
        public static DataTable GetAllCatagories()
        {            
            return DBConnection.TableFromDataBase("GetAllCatagories");
        }



    }
}

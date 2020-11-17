using System.Data;

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

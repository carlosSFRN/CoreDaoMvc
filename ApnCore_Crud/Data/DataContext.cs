using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Data
{
    public class DataContext
    {
        public static string GetConnection()
        {
            return @"Server=DESKTOP-29H7J25\SQLEXPRESS;Database=Stoke;Trusted_Connection=True;";
        }
    }
}

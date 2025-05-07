using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Library
{
    public class FilterByUser : Filter
    {
        public int userIDToInclude = 1;

        public string applyFilter()
        {
            return $" AND userID = {userIDToInclude}";
        }
    }
}

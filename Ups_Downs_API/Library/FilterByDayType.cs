using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Library
{
    public class FilterByDayType : Filter
    {
        public string dayTypeToInclude = "test";

        public string applyFilter()
        {
            return $" AND dayType = '{dayTypeToInclude}'";
        }
    }
}

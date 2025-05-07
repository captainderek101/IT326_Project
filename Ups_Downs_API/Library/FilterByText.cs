using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Library
{
    public class FilterByText : Filter
    {
        public string textToExclude = "";

        public string applyFilter()
        {
            return $" WHERE message NOT LIKE '%{textToExclude}%'";
        }
    }
}

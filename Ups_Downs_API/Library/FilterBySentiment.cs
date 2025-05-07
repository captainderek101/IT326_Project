using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Library
{
    public class FilterBySentiment : Filter
    {
        public string sentimentToInclude = "test";

        public string applyFilter()
        {
            return $" AND sentiment = '{sentimentToInclude}'";
        }
    }
}

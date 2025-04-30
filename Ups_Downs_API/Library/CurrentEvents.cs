using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CurrentEvents
    {
        public string positiveMessage { get; set; }
        public List<NewsArticle> articles { get; set; }

        public CurrentEvents()
        {
            articles = new List<NewsArticle>();
        }
    }
}

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
        public static CurrentEvents dummy()
        {
            CurrentEvents temp = new();
            temp.positiveMessage = "you can do it";
            for (int i = 0; i < 3; i++)
            {
                temp.articles.Add(new NewsArticle("number " + i, "URL"));
            }
            return temp;
        }
    }
}

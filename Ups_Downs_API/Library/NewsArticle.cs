using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class NewsArticle
    {
        string title { get; set; }
        string address { get; set; }
        DateTime timestamp { get; }

        public NewsArticle(string title, string address)
        {
            this.title = title;
            this.address = address; 
            timestamp = DateTime.Now;
        }
        public string DisplayArticle()
        {
            return title + "\n" + address;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library
{
    public class NewsArticle
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string address { get; set; }

        [JsonConstructor]
        public NewsArticle(string title, string address)
        {
            this.title = title;
            this.address = address; 
        }
        public string DisplayArticle()
        {
            return title + "\n" + address;
        }
    }
}

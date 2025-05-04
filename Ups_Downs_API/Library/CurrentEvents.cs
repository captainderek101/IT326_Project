using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class CurrentEvents
    {
        [Required]
        public string? positiveMessage { get; set; }
        [Required]
        public List<NewsArticle> articles { get; set; }

        [JsonConstructor]
        public CurrentEvents()
        {
            articles = new List<NewsArticle>();
        }
    }
}

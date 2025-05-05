using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Library
{
    public class PostObject
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
        [Required]
        public string Content { get; set; }
        public string DayType { get; set; }
        public string Sentiment { get; set; }
        public SqlDateTime LastUpdated { get; set; }

        public PostObject()
        {
            UserID = 1;
            PostID = 1;
            Content = "test";
            DayType = "test";
            Sentiment = "test";
        }
        public PostObject(string content)
        {
            Content = content;
            UserID = 1;
            PostID = 1;
            DayType = "test";
            Sentiment = "test";
        }

    }
}

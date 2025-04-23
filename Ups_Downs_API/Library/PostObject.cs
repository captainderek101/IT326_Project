using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Library
{
    public class PostObject
    {
        public int PostID { get; set; }
        [Required]
        public string Content { get; set; }

        public PostObject()
        {
            PostID = 1;
            Content = "test";
        }
        public PostObject(string content)
        {
            Content = content;
        }

    }
}

using System.Xml.Linq;

namespace Library
{
    public class PostObject
    {
        public string Content { get; set; }

        public PostObject()
        {
            Content = "test";
        }
        public PostObject(string content)
        {
            Content = content;
        }

    }
}

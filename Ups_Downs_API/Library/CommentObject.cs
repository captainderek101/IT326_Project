using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Library
{
    public class CommentObject
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public string Content { get; set; }
        public CommentObject(int userID, int postID, string content) =>
            (UserID, PostID, Content) = (userID, postID, content);
    }
}

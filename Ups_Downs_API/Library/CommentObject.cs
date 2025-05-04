using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Library
{
    public class CommentObject
    {
        public required int UserID { get; set; }
        public required int PostID { get; set; }
        public required string Content { get; set; }

        public CommentObject()
        {
            UserID = 0;
            PostID = 0;
            Content = "test comment!";
        }
        [SetsRequiredMembers]
        public CommentObject(int userID, int postID, string content) =>
            (UserID, PostID, Content) = (userID, postID, content);
    }
}

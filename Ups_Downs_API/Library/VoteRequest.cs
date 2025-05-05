using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Library
{
    public class VoteRequest
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public bool Upvote { get; set; }
        [Required]
        public bool Downvote { get; set; }
        public VoteRequest(int userID, int postID, bool upvote, bool downvote) =>
            (UserID, PostID, Upvote, Downvote) = (userID, postID, upvote, downvote);
    }
}

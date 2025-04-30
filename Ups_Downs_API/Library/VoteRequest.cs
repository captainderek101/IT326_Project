using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Library
{
    public class VoteRequest
    {
        public required int UserID { get; set; }
        public required int PostID { get; set; }
        public required bool Upvote { get; set; }
        public required bool Downvote { get; set; }

        public VoteRequest()
        {
            UserID = 0;
            PostID = 0;
            Upvote = true;
            Downvote = false;
        }
        [SetsRequiredMembers]
        public VoteRequest(int userID, int postID, bool upvote, bool downvote) =>
            (UserID, PostID, Upvote, Downvote) = (userID, postID, upvote, downvote);
    }
}

using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Library
{
    public class SubscriptionRequest
    {
        public required int UserID { get; set; }
        public required int PostID { get; set; }
        public required string EmailAddress { get; set; }
        public required bool Subscribe { get; set; }

        public SubscriptionRequest()
        {
            UserID = 0;
            PostID = 0;
            EmailAddress = "test@test.com";
            Subscribe = true;
        }
        [SetsRequiredMembers]
        public SubscriptionRequest(int userID, int postID, string emailAddress, bool subscribe) =>
            (UserID, PostID, EmailAddress, Subscribe) = (userID, postID, emailAddress, subscribe);
    }
}

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Library
{
    public class SubscriptionRequest
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public bool Subscribe { get; set; }
        public SubscriptionRequest(int userID, int postID, string emailAddress, bool subscribe) =>
            (UserID, PostID, EmailAddress, Subscribe) = (userID, postID, emailAddress, subscribe);
    }
}

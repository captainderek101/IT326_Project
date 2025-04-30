using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Library
{
    public class ReportRequest
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PostID { get; set; }

        public ReportRequest()
        {
            UserID = 0;
            PostID = 0;
        }
        [SetsRequiredMembers]
        public ReportRequest(int userID, int postID) =>
            (UserID, PostID) = (userID, postID);
    }
}

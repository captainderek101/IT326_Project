using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Library
{
    public class ReportRequest
    {
        public required int UserID { get; set; }
        public required int PostID { get; set; }

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

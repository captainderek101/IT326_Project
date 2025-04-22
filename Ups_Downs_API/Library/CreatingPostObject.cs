using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class CreatingPostObject
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string PostDayType { get; set; }

        [Required]
        public string PostTimestamp { get; set; }
        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }

        public CreatingPostObject(
            int postId,
            string postDayType,
            string postTimestamp,
            int userID,
            string content)
        {
            PostId = postId;
            PostDayType = postDayType;
            PostTimestamp = postTimestamp;
            UserId = userID;
            Content = content;
        }
    }
}
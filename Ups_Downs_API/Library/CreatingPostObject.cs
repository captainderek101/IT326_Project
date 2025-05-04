using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Library
{
    public class CreatingPostObject
    {
        [Required]
        public int PostId { get; set; } //db [postID]

        [Required]
        public string PostDayType { get; set; } //db [dayType]

        [Required]
        public string PostTimestamp { get; set; } //db [lastUpdated]
        public int UserId { get; set; } //db [userID]

        [Required]
        public string Content { get; set; } //db [message]

        [Required]
        public double SentimentScore { get; set; }

        public string? SentimentWord { get; set; } //db [sentiment]

        public CreatingPostObject(int postId, string postDayType, string postTimestamp, int userID, string content, double sentimentScore)
        {
            PostId = postId;
            PostDayType = postDayType;
            PostTimestamp = postTimestamp;
            UserId = userID;
            Content = content;
            SentimentScore = sentimentScore;
            SentimentWord = null;
        }
    }
}
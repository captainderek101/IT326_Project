using System.ComponentModel.DataAnnotations;
using System.Numerics;

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

        [Required]
        public double SentimentScore { get; set; }

        public string? SentimentWord { get; set; }

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
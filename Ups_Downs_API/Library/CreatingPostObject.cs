namespace Library
{
    public class CreatingPostObject
    {
        public required int PostId { get; set; }
        public required string PostDayType { get; set; }
        public required string PostTimestamp { get; set; }
        public int UserId { get; set; }
        public required string Content { get; set; }

        public CreatingPostObject(int postId, string postDayType, string postTimestamp, int userID, string content)
        {
            PostId = postId;
            PostDayType = postDayType;
            PostTimestamp = postTimestamp;
            UserId = userID;
            Content = content;
        }
    }
}
namespace Library
{
    public class CreatingPostObject
    {
        public required int PostId { get; set; }
        public required string PostDayType { get; set; }
        public required string PostTimestamp { get; set; }
        public int UserId { get; set; }
        public required string Content { get; set; }
    }
}
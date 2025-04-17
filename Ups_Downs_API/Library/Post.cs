/* Contains the post object
 */

using System.Net;

namespace Library
{
    public class Post
    {
        private User creator {  get; set; }
        //TODO: Create dependent classes
        private DayType dayType {  get; set; }
        private Sentiment sentiment { get; set; }
        //private List <UserPostRating> ratings {  get; set; }
        private List<Comment>? comments { get; set; }
        //TODO: Create post constructor
        public Post(User creator, DayType daytype, Sentiment sentiment, List<Comment> comments)
        { 
            this.creator = creator;
            this.dayType = daytype;
            this.sentiment = sentiment;
            this.comments = comments;
        }
    }
}

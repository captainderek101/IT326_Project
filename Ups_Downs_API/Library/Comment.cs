/* Class for comment object
 */

namespace Library
{
    public class Comment
    {
        private string content {  get; set; }
        private Post post { get; set; }
        private User creator { get; set; }
        
        public Comment(string content, Post post, User user)
        {
            this.content = content;
            this.post = post;
            this.creator = user;
        }
    }
}

/* Contains the user object
 */

namespace Library
{
    public class User
    {
        private int userId { get; set; }
        private string userName { get; set; }
        
        public User(int userId, string name)
        {
            this.userId = userId;
            this.userName = name;
        }
    }
}

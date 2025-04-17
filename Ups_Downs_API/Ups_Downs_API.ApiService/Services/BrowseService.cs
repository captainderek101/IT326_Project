using Library;
using Microsoft.AspNetCore.Identity;

namespace Ups_Downs_API.ApiService.Services
{
    public class BrowseService
    {
        //private readonly TempGlobalSingleton _TempDB;//remove later, temporary database
        public List<Post> ProcessBrowse(string filter)
        {
            Console.WriteLine("Recieved Browse Request in Service");
            //temporary database connection logic
            //UserObject? tempUser = _TempDB.GetUser(obj);
            List<Post> list = new List<Post>();
            List<Comment> comments = new List<Comment>();
            list.Add(new Post(new User(1, filter), DayType.good, Sentiment.cheerful,comments));
            return list; // TODO: add real logic
        }
    }
}

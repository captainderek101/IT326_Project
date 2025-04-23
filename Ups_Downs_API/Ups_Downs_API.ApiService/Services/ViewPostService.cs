using Library;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Database;

namespace Ups_Downs_API.ApiService.Services
{
    public class ViewPostService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        // Constructor Injection
        public ViewPostService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public object GetPost(int postID)
        {
            // TODO: DB connection here
            PostObject obj = new PostObject();
            obj.PostID = postID;

            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                var command = new SqlCommand($"SELECT message FROM Posts WHERE postID = {postID};", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj.Content = reader.GetString(0);
                }
                reader.Close();
            }

            return obj;
        }
        public ReportRequest PostReport(ReportRequest obj)
        {
            // TODO: DB connection here
            return obj;
        }
        public VoteRequest PutVote(VoteRequest obj)
        {
            // TODO: DB connection here
            return obj;
        }
        public CommentObject PostComment(CommentObject obj)
        {
            // TODO: DB connection here
            return obj;
        }
        public SubscriptionRequest PostSubscribe(SubscriptionRequest obj)
        {
            // TODO: DB connection here
            return obj;
        }
    }
}

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

        public object GetPost(PostObject obj)
        {
            // TODO: DB connection here
            obj.Content = "test";

            string names = "";
            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                var command = new SqlCommand("SELECT FirstName, LastName FROM TEST_Gamers;", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    names += reader.GetString(0);
                    names += " ";
                    names += reader.GetString(1);
                    names += ", ";
                }
                reader.Close();
            }
            Console.WriteLine(names);

            var v = new
            {
                Content = obj.Content
            };

            return v;
        }
        public void PostReport(ReportRequest obj)
        {
            // TODO: DB connection here
        }
        public void PutVote(VoteRequest obj)
        {
            // TODO: DB connection here
        }
        public void PostComment(CommentObject obj)
        {
            // TODO: DB connection here
        }
        public void PostSubscribe(SubscriptionRequest obj)
        {
            // TODO: DB connection here
        }
    }
}

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
            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                var command = new SqlCommand($"INSERT INTO Reports(userID, postID) VALUES({obj.UserID}, {obj.PostID});", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

            return obj;
        }
        public VoteRequest PutVote(VoteRequest obj)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                var command = new SqlCommand($"IF EXISTS (SELECT * FROM UserPostRatings WHERE userID = {obj.UserID} AND postID = {obj.PostID})" +
                    $" BEGIN" +
                    $" UPDATE UserPostRatings SET upvote = '{obj.Upvote}', downvote = '{obj.Downvote}' WHERE userID = {obj.UserID} AND postID = {obj.PostID}" +
                    $" END" +
                    $" ELSE" +
                    $" BEGIN" +
                    $" INSERT INTO UserPostRatings(userID, postID, upvote, downvote) VALUES({obj.UserID}, {obj.PostID}, '{obj.Upvote}', '{obj.Downvote}')" +
                    $" END", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

            return obj;
        }
        public CommentObject PostComment(CommentObject obj)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                var command = new SqlCommand($"INSERT INTO Comments(userID, postID, message) VALUES({obj.UserID}, {obj.PostID}, '{obj.Content}');", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

            return obj;
        }
        public SubscriptionRequest PostSubscribe(SubscriptionRequest obj)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                var command = new SqlCommand($"INSERT INTO Subscriptions(userID, postID, emailAddress) VALUES({obj.UserID}, {obj.PostID}, '{obj.EmailAddress}');", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

            return obj;
        }
    }
}

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

        public PostObject GetPost(int postID)
        {
            PostObject obj = new PostObject();
            obj.PostID = postID;

            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                var command = new SqlCommand($"SELECT userID, postID, message, dayType, sentiment, lastUpdated FROM Posts WHERE postID = @postID;", connection);
                command.Parameters.AddWithValue("@postID", postID);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    obj.UserID = reader.GetInt32(0);
                    obj.PostID = reader.GetInt32(1);
                    if(!reader.IsDBNull(2))
                    {
                        obj.Content = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        obj.DayType = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        obj.Sentiment = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        obj.LastUpdated = reader.GetSqlDateTime(5);
                    }
                }
                reader.Close();
            }

            return obj;
        }

        public List<CommentObject> GetComments(int postID)
        {
            List<CommentObject> obj = new List<CommentObject>();

            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                var command = new SqlCommand($"SELECT userID, postID, message, lastUpdated FROM Comments WHERE postID = @postID;", connection);
                command.Parameters.AddWithValue("@postID", postID);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CommentObject comment = new CommentObject(0, 0, "");
                    comment.UserID = reader.GetInt32(0);
                    comment.PostID = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                    {
                        comment.Content = reader.GetString(2);
                    }
                    obj.Add(comment);
                }
                reader.Close();
            }

            return obj;
        }
        public ReportRequest PostReport(ReportRequest obj)
        {
            if (obj.UserID != 1)
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var connection = (SqlConnection)context.Database.GetDbConnection();
                    var command = new SqlCommand($"IF NOT EXISTS (SELECT * FROM Reports WHERE userID = @userID AND postID = @postID)" +
                        $" BEGIN" +
                        $" INSERT INTO Reports(userID, postID) VALUES(@userID, @postID)" +
                        $" END", connection);
                    command.Parameters.AddWithValue("@userID", obj.UserID);
                    command.Parameters.AddWithValue("@postID", obj.PostID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return obj;
        }
        public VoteRequest PutVote(VoteRequest obj)
        {
            if (obj.UserID != 1)
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var connection = (SqlConnection)context.Database.GetDbConnection();
                    var command = new SqlCommand($"IF EXISTS (SELECT * FROM UserPostRatings WHERE userID = @userID AND postID = @postID)" +
                        $" BEGIN" +
                        $" UPDATE UserPostRatings SET upvote = @upvote, downvote = @downvote WHERE userID = @userID AND postID = @postID" +
                        $" END" +
                        $" ELSE" +
                        $" BEGIN" +
                        $" INSERT INTO UserPostRatings(userID, postID, upvote, downvote) VALUES(@userID, @postID, @upvote, @downvote)" +
                        $" END", connection);
                    command.Parameters.AddWithValue("@userID", obj.UserID);
                    command.Parameters.AddWithValue("@postID", obj.PostID);
                    command.Parameters.AddWithValue("@upvote", obj.Upvote);
                    command.Parameters.AddWithValue("@downvote", obj.Downvote);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return obj;
        }
        public CommentObject PostComment(CommentObject obj)
        {
            if(obj.UserID != 1)
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var connection = (SqlConnection)context.Database.GetDbConnection();
                    var command = new SqlCommand($"INSERT INTO Comments(userID, postID, message) VALUES(@userID, @postID, @content);", connection);
                    command.Parameters.AddWithValue("@userID", obj.UserID);
                    command.Parameters.AddWithValue("@postID", obj.PostID);
                    command.Parameters.AddWithValue("@content", obj.Content);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return obj;
        }
        public SubscriptionRequest PostSubscribe(SubscriptionRequest obj)
        {
            if (obj.UserID == 1)
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var connection = (SqlConnection)context.Database.GetDbConnection();
                    var command = new SqlCommand($"IF EXISTS (SELECT * FROM Subscriptions WHERE userID = @userID AND postID = @postID AND emailAddress = @emailAddress)" +
                        $" BEGIN" +
                        $" UPDATE Subscriptions SET active = @active WHERE userID = @userID AND postID = @postID AND emailAddress = @emailAddress" +
                        $" END" +
                        $" ELSE" +
                        $" BEGIN" +
                        $" INSERT INTO Subscriptions(userID, postID, emailAddress, active) VALUES(@userID, @postID, @emailAddress, @active)" +
                        $" END", connection);
                    command.Parameters.AddWithValue("@userID", obj.UserID);
                    command.Parameters.AddWithValue("@postID", obj.PostID);
                    command.Parameters.AddWithValue("@emailAddress", obj.EmailAddress);
                    command.Parameters.AddWithValue("@active", obj.Subscribe);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var connection = (SqlConnection)context.Database.GetDbConnection();
                    var command = new SqlCommand($"IF EXISTS (SELECT * FROM Subscriptions WHERE userID = @userID AND postID = @postID AND userID != 1)" +
                        $" BEGIN" +
                        $" UPDATE Subscriptions SET emailAddress = @emailAddress, active = @active WHERE userID = @userID AND postID = @postID" +
                        $" END" +
                        $" ELSE" +
                        $" BEGIN" +
                        $" INSERT INTO Subscriptions(userID, postID, emailAddress, active) VALUES(@userID, @postID, @emailAddress, @active)" +
                        $" END", connection);
                    command.Parameters.AddWithValue("@userID", obj.UserID);
                    command.Parameters.AddWithValue("@postID", obj.PostID);
                    command.Parameters.AddWithValue("@emailAddress", obj.EmailAddress);
                    command.Parameters.AddWithValue("@active", obj.Subscribe);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return obj;
        }
    }
}

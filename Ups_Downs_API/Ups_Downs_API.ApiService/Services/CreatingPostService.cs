using Library;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Database;

namespace Ups_Downs_API.ApiService.Services
{
    public class CreatingPostService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        // Constructor Injection
        public CreatingPostService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public CreatingPostObject ProcessCreatingPost(CreatingPostObject obj)
        {
            Console.Write("Here is the post time stamp: ");
            Console.WriteLine(obj.PostTimestamp);
            
            using (var context = _contextFactory.CreateDbContext())
            {

                // Format sentiment score to filterable words: happy, neutral, upset
                double score = Math.Round(obj.SentimentScore, 3);
                if (score > 0.25)
                {
                    obj.SentimentWord = "Happy";
                }

                else if (score <= 0.25 && score >= -0.25)
                {
                    obj.SentimentWord = "Neutral";
                }

                else
                {
                    obj.SentimentWord = "Upset";
                }

                var connection = (SqlConnection)context.Database.GetDbConnection();
                connection.Open();

                var command = new SqlCommand("INSERT INTO Posts (userID, lastUpdated, dayType, sentiment, message) VALUES (@userID, @lastUpdated, @dayType, @sentiment, @message)", connection);

                command.Parameters.AddWithValue("@userID", obj.UserId);
                command.Parameters.AddWithValue("@lastUpdated", obj.PostTimestamp);
                command.Parameters.AddWithValue("@dayType", obj.PostDayType);
                command.Parameters.AddWithValue("@sentiment", obj.SentimentWord);
                command.Parameters.AddWithValue("@message", obj.Content);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Post created");

            }

            return obj;
        }
    }
}

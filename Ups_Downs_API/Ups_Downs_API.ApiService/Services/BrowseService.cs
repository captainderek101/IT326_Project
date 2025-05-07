using Library;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Database;

namespace Ups_Downs_API.ApiService.Services
{
    public class BrowseService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        // Constructor Injection
        public BrowseService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<PostObject> ProcessBrowse(string filterType, string filterValue)
        {
            List<PostObject> list = new List<PostObject>();
            Filter filter;

            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                string query = "SELECT userID, postID, message, dayType, sentiment, lastUpdated FROM Posts";
                switch(filterType)
                {
                    case "content":
                        filter = new FilterByText();
                        ((FilterByText)filter).textToExclude = filterValue;
                        query += filter.applyFilter();
                        break;
                    case "user":
                        if (Int32.TryParse(filterValue, out int userID))
                        {
                            filter = new FilterByUser();
                            ((FilterByUser)filter).userIDToInclude = userID;
                            query += filter.applyFilter();
                        }
                        break;
                    case "dayType":
                        filter = new FilterByDayType();
                        ((FilterByDayType)filter).dayTypeToInclude = filterValue;
                        query += filter.applyFilter();
                        break;
                    case "sentiment":
                        filter = new FilterBySentiment();
                        ((FilterBySentiment)filter).sentimentToInclude = filterValue;
                        query += filter.applyFilter();
                        break;
                    default:
                        break;
                }
                var command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PostObject newPost = new PostObject("test");
                    newPost.UserID = reader.GetInt32(0);
                    newPost.PostID = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                    {
                        newPost.Content = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        newPost.DayType = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        newPost.Sentiment = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        newPost.LastUpdated = reader.GetSqlDateTime(5);
                    }
                    list.Add(newPost);
                }
                reader.Close();
            }

            return list;
        }
    }
}

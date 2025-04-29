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

            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                string query = "SELECT message FROM Posts";
                switch(filterType)
                {
                    case "content":
                        query += $" WHERE message LIKE '{filterValue}'";
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
                    newPost.Content = reader.GetString(0);
                    list.Add(newPost);
                }
                reader.Close();
            }

            return list;
        }
    }
}

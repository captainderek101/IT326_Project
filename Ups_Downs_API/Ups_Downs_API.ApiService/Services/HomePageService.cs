using Library;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Database;

namespace Ups_Downs_API.ApiService.Services
{
    public class HomePageService
    {
        //private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        //private CurrentEvents _currentEvents;

        // Constructor Injection
       // public HomePageService(IDbContextFactory<ApplicationDbContext> contextFactory)
        //{
        //    _contextFactory = contextFactory;
        //}

        public CurrentEvents getCurrentEvents()
        {
            CurrentEvents currentEvents = new CurrentEvents();
            // For use integrating database connection later
            //using (var context = _contextFactory.CreateDbContext())
            //{
            //    var connection = (SqlConnection)context.Database.GetDbConnection();
            //    string query = "SELECT title FROM Articles";
            //    var command = new SqlCommand(query, connection);

            //    connection.Open();
            //    var reader = command.ExecuteReader();

            //    while (reader.Read())
            //   {
            //TODO: fix logic
            //        currentEvents.articles[0].title = (reader.GetString(0));
            //    }
            //    reader.Close();
            //}
            // Testing things
            currentEvents.positiveMessage = "you can('t) do it";
            for (int i = 0; i < 3; i++)
            {
                currentEvents.articles.Add(new NewsArticle("number: " + (i + i), "URL"));
            }

            return currentEvents;
        }
    }
}

using Library;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Database;
// For News API
using System.Collections.Generic;
using System.Diagnostics;
using worldnewsapi.Api;
using worldnewsapi.Client;
using worldnewsapi.Model;
using static System.Net.WebRequestMethods;

namespace Ups_Downs_API.ApiService.Services
{
    public class HomePageService
    {
        // TODO: for database integration later
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

            // TODO: add database connectivity
            //using (var context = _contextFactory.CreateDbContext())
            //{
            //    var connection = (SqlConnection)context.Database.GetDbConnection();
            //    string query = "SELECT title, url FROM Articles";
            //    var command = new SqlCommand(query, connection);

            //    connection.Open();
            //    var reader = command.ExecuteReader();

            //    while (reader.Read())
            //   {
            //          TODO: fix logic
            //        currentEvents.articles[0].title = (reader.GetString(0));
            //    }
            //    reader.Close();
            //}

            // If read database and results are outdated, then generate new articles
            // OR somethign IDK
            bool isOutdated = true;
            if (isOutdated)
            {
                // Insert world news api key here!
                string apiKey = "";
                // Copied shamelessly from the exapmle given
                Configuration config = new Configuration();
                config.BasePath = "https://api.worldnewsapi.com";
                // Configure API key authorization: apiKey
                config.AddApiKey("api-key", apiKey);
                // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
                // config.AddApiKeyPrefix("api-key", "Bearer");
                // Configure API key authorization: headerApiKey
                config.AddApiKey("x-api-key", apiKey);
                // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
                // config.AddApiKeyPrefix("x-api-key", "Bearer");

                var apiInstance = new NewsApi(config);
                string? text = null;  
                string? textMatchIndexes = null; 
                string sourceCountry = "us";  
                string language = "en";  
                double minSentiment = 0.8;  
                double maxSentiment = 1;  
                string earliestPublishDate = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");  // TODO: Hopefully this works :)
                string? latestPublishDate = null;  
                string? newsSources = null;  
                string? authors = null;  
                string? categories = null; 
                string? entities = null;  
                string? locationFilter = null;  
                string? sort = null;  
                string? sortDirection = null;  
                int? offset = 0;  
                int? number = 3; 

                try
                {
                    // Search News
                    SearchNews200Response result = apiInstance.SearchNews(text, textMatchIndexes, sourceCountry, language, minSentiment, maxSentiment, earliestPublishDate, latestPublishDate, newsSources, authors, categories, entities, locationFilter, sort, sortDirection, offset, number);
                    // Put News Results into current events
                    for (int i = 0; i < 3; i++)
                    {
                        currentEvents.articles.Add(new NewsArticle(result.News[i].Title, result.News[i].Url));
                    }
                    // TODO: Will need to also add them to database

                }
                catch (ApiException e)
                {
                    Debug.Print("Exception when calling NewsApi.SearchNews: " + e.Message);
                    Debug.Print("Status Code: " + e.ErrorCode);
                    Debug.Print(e.StackTrace);
                }
            }
            // TODO: Insert Positive message
            currentEvents.positiveMessage = "Consider voluntary euthanasia";
            return currentEvents;
        }
    }
}

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
using System.Runtime.CompilerServices;

namespace Ups_Downs_API.ApiService.Services
{
    public class HomePageService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IConfiguration _config;

        public HomePageService(
            IDbContextFactory<ApplicationDbContext> contextFactory,
            IConfiguration config)
        {
            _contextFactory = contextFactory;
            _config = config;
        }

        public CurrentEvents getCurrentEvents()
        {
            CurrentEvents currentEvents = new CurrentEvents();

            bool isOutdated = true; // Check if db info outdated
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            //  Db connection
            using (var context = _contextFactory.CreateDbContext())
            {
                var connection = (SqlConnection)context.Database.GetDbConnection();
                string query = "SELECT TOP 1 time FROM Articles;";
                var command = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    //3 cases - db is empty, db is outdated, or db is up to date
                    //Checking timestamp/if database is outdated
                    while (reader.Read())
                    {
                        // If the date lines up, then they aren't outdated
                        isOutdated = (reader.GetString(0) != today);
                    }
                }
                if (!isOutdated)
                {
                    //  If not outdated, then read articles into current events
                    query = "SELECT title, url FROM Articles;";
                    command = new SqlCommand(query, connection);

                    using (var reader = command.ExecuteReader())
                    {
                        //  reading articles into db
                        while (reader.Read())
                        {
                            currentEvents.articles.Add(new NewsArticle(reader.GetString(0), reader.GetString(1)));
                        }
                    }

                    // If articles outdated, read new articles
                }
                else
                {
                    //clearing database of outdated entries
                    query = "DELETE FROM Articles;";
                    command = new SqlCommand(query, connection);

                    command.ExecuteNonQuery();

                    // Insert world news api key here!
                    string apiKey = _config["WorldNewsApi:ApiKey"];   // pulled from config/env/secret
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
                    double minSentiment = 0.7;
                    double maxSentiment = 1;
                    string earliestPublishDate = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
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

                            command = new SqlCommand("INSERT INTO Articles VALUES (@Title, @Url, @time);", connection);
                            command.Parameters.AddWithValue("@Title", result.News[i].Title);
                            command.Parameters.AddWithValue("@Url", result.News[i].Url);
                            command.Parameters.AddWithValue("@time", today);


                            command.ExecuteNonQuery();
                        }
                    }
                    catch (ApiException e)
                    {
                        Debug.Print("Exception when calling NewsApi.SearchNews: " + e.Message);
                        Debug.Print("Status Code: " + e.ErrorCode);
                        Debug.Print(e.StackTrace);
                    }
                }
                // Get Positive message from quote table
                // determine if quote chosen for day, if not choose quote
                isOutdated = true;
                query = "SELECT time FROM CurQuote;";
                command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    // Checking if date chosen is up to date
                    if (reader.Read())
                    {
                        isOutdated = (reader.GetString(0) != today);
                    }
                }
                if (!isOutdated)
                {
                    // Finding quote from CurQuote Table
                    query = "SELECT id FROM CurQuote;";
                    command = new SqlCommand(query, connection);
                    int index;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            index = reader.GetInt32(0);
                        }
                        else
                        {
                            currentEvents.positiveMessage = "Error";
                            return currentEvents;
                        }
                    }
                    query = "SELECT text FROM Quotes WHERE id = " + index + ";";
                    command = new SqlCommand(query, connection);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentEvents.positiveMessage = reader.GetString(0);
                        }
                        else
                        {
                            currentEvents.positiveMessage = "Error";
                            return currentEvents;
                        }
                    }
                }
                else
                {
                    // Select new quote
                    query = "DELETE FROM CurQuote;";
                    command = new SqlCommand(query, connection);

                    command.ExecuteNonQuery();

                    // find random entry in SQL
                    query = "SELECT TOP 1 id, text FROM Quotes ORDER BY NEWID();";
                    command = new SqlCommand(query, connection);
                    int index;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            index = reader.GetInt32(0);
                            currentEvents.positiveMessage = reader.GetString(1);
                        }
                        else
                        {
                            currentEvents.positiveMessage = "Error";
                            return currentEvents;
                        }
                    }
                    // Save result to table
                    command = new SqlCommand("INSERT INTO CurQuote VALUES (@id, @time);", connection);
                    command.Parameters.AddWithValue("@id", index);
                    command.Parameters.AddWithValue("@time", today);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return currentEvents;
        }
    }
}
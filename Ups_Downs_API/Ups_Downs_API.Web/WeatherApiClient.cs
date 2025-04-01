using System.Text;
using Microsoft.Data.SqlClient;

namespace Ups_Downs_API.Web;

public class WeatherApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> GetWeatherAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<WeatherForecast>? forecasts = null;

        await foreach (var forecast in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/weatherforecast", cancellationToken))
        {
            if (forecasts?.Count >= maxItems)
            {
                break;
            }
            if (forecast is not null)
            {
                forecasts ??= [];
                forecasts.Add(forecast);
            }
        }

        return forecasts?.ToArray() ?? [];
    }


    public string ConnectToDB()
    {
        string names = "";
        try
        {
            // Build connection string
            Microsoft.Data.SqlClient.SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder("Server=.\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");

            // Connect to SQL
            Console.Write("Connecting to SQL Server ... ");
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done.");

                // READ demo
                Console.WriteLine("Reading from DB...");
                string sql = "SELECT FirstName, LastName FROM TEST_Gamers;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names += reader.GetString(0);
                            names += " ";
                            names += reader.GetString(1);
                            names += ", ";
                        }
                        Console.WriteLine("Done.");
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
        return names;
    }

    public void AddDBEntry()
    {
        try
        {
            // Build connection string
            Microsoft.Data.SqlClient.SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder("Server=.\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");

            // Connect to SQL
            Console.Write("Connecting to SQL Server ... ");
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Console.WriteLine("Done.");

                // Insert some sample data
                Console.WriteLine("Inserting new data...");
                StringBuilder sb = new StringBuilder();
                sb.Append("USE master; ");
                sb.Append("INSERT INTO TEST_Gamers (FirstName, LastName) VALUES ");
                sb.Append("('Another', 'Dude!');");
                string sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done.");
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

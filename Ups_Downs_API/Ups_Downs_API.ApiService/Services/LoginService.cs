using Library;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Database;
using BCrypt.Net;

namespace Ups_Downs_API.ApiService.Services
{
    public class LoginService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        // Constructor Injection
        public LoginService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //private readonly DbContext
        public User ProcessLoginPost(LoginRequest loginAttempt)
        {
            User user = new User("username", "password", "email");
            //database connection

            using (var context = _contextFactory.CreateDbContext())
            {
                Console.WriteLine("Entered DB connection in LoginService for login attempt");
                var connection = (SqlConnection)context.Database.GetDbConnection();
                connection.Open();

                var command = new SqlCommand(
                    "SELECT userID, username, passwordHash, emailAddress FROM Users WHERE username = @username",
                    connection
                );

                command.Parameters.AddWithValue("@username", loginAttempt.Username);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(loginAttempt.Password);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string uname = reader.GetString(1);
                    string pw = reader.GetString(2);
                    string? email = reader.IsDBNull(3) ? null : reader.GetString(3);

                    Console.Write("Found account for ");
                    Console.Write(uname);
                    Console.Write(" , ID: ");
                    Console.WriteLine(id);

                    if (BCrypt.Net.BCrypt.Verify(loginAttempt.Password, hashedPassword))
                        return new User(id, uname, pw, email);

                    return null;
                }
                Console.WriteLine("No Account Found");
                return null; // No matching user
            }
        }

        public bool ProcessAccountCreationPost(CreateAccountObject obj)
        {
            //DB connection here
            using (var context = _contextFactory.CreateDbContext())
            {
                Console.WriteLine("Entered DB connection in LoginService for account creation");
                var connection = (SqlConnection)context.Database.GetDbConnection();
                connection.Open();

                var command = new SqlCommand("INSERT INTO Users (username, passwordHash) VALUES (@username, @passwordHash)", connection);

                command.Parameters.AddWithValue("@username", obj.Username);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(obj.Password);
                command.Parameters.AddWithValue("@passwordHash", hashedPassword);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Account created");
                    return rowsAffected > 0;
                }
                catch (SqlException exception)
                {
                    if (exception.Number == 2627)
                    {
                        Console.WriteLine("Username already exists.");
                        return false;
                    }

                    // Log or rethrow for other SQL exceptions
                    Console.WriteLine($"SQL error {exception.Number}: {exception.Message}");
                    return false;
                }
                
            }
        }

        public User ProcessUpdateAccountPost(User obj)
        {
            //DB connection here
            using (var context = _contextFactory.CreateDbContext())
            {
                Console.WriteLine("Entered DB connection in LoginService for updating account information");
                var connection = (SqlConnection)context.Database.GetDbConnection();
                connection.Open();

                var command = new SqlCommand("UPDATE Users SET username = @username, passwordHash = @passwordHash, emailAddress = @email  WHERE userID = @userID", connection);

                command.Parameters.AddWithValue("@username", obj.Username);
                command.Parameters.AddWithValue("@passwordHash", obj.Password);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@userID", obj.UserID);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Account Updated");
                    return obj;
                }
                catch (SqlException exception)
                {
                    if (exception.Number == 2627)
                    {
                        Console.WriteLine("Username already exists.");
                        return null;
                    }

                    // Log or rethrow for other SQL exceptions
                    Console.WriteLine($"SQL error {exception.Number}: {exception.Message}");
                    return null;
                }

            }

            return null; //account was not updated
        }
    }
}

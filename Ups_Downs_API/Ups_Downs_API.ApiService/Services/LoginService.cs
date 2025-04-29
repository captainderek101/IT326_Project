using Library;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Database;

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
            //TODO: database connection

            using (var context = _contextFactory.CreateDbContext())
            {
                Console.WriteLine("Entered DB connection in LoginService for login attempt");
                var connection = (SqlConnection)context.Database.GetDbConnection();
                connection.Open();

                var command = new SqlCommand(
                    "SELECT username, passwordHash, emailAddress FROM Users WHERE username = @username AND passwordHash = @password;",
                    connection
                );

                command.Parameters.AddWithValue("@username", loginAttempt.Username);
                command.Parameters.AddWithValue("@password", loginAttempt.Password); // Make sure password is hashed if you hash during storage

                Console.WriteLine($"Attempting login with username: {loginAttempt.Username}, password: {loginAttempt.Password}");

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string uname = reader.GetString(0);
                    string pw = reader.GetString(1);
                    string? email = reader.IsDBNull(2) ? null : reader.GetString(2);

                    Console.Write("Found account for ");
                    Console.WriteLine(uname);

                    return new User(uname, pw, email);
                }
                Console.WriteLine("No Account Found");
                return null; // No matching user
            }
        }

        public bool ProcessAccountCreationPost(CreateAccountObject obj)
        {
            // TODO: DB connection here
            using (var context = _contextFactory.CreateDbContext())
            {
                Console.WriteLine("Entered DB connection in LoginService for account creation");
                var connection = (SqlConnection)context.Database.GetDbConnection();
                connection.Open();

                var command = new SqlCommand("INSERT INTO Users (username, passwordHash) VALUES (@username, @passwordHash)", connection);

                command.Parameters.AddWithValue("@username", obj.Username);
                command.Parameters.AddWithValue("@passwordHash", obj.Password);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Account created");
                return rowsAffected > 0;
            }
        }

        public bool ProcessForgotPwPost(ForgotPasswordObject obj)
        {
            // TODO: DB connection here

            return true;//password was changed
        }

        public bool ProcessUpdateAccountPost(User obj)
        {
            // TODO: DB connection here

            return true; //account was updated
        }

        public bool ProcessEmailValidationPost(User obj)
        {
            // TODO: DB connection here

            return true; //email was verified
        }
    }
}

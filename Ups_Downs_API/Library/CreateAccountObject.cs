using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library
{
    public class CreateAccountObject
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [JsonConstructor]
        public CreateAccountObject(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}

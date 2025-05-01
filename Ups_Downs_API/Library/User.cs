using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library
{
    public class User
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string? Email { get; set; }

        [JsonConstructor]
        public User(int userID, string username, string password, string? email)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Email = email;
        }

        public User( string username, string password, string? email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}

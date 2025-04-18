using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class User
    {
        [Required]
        public string _username { get; set; }

        [Required]
        public string? _password { get; set; }
        public string? _email { get; set; }

        public User(string name, string pw, string em)
        {
            _username = name;
            _password = pw;
            _email = em;
        }
    }
}

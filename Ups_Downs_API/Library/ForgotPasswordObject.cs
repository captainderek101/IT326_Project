using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ForgotPasswordObject
    {
        [Required]
        public string _username;

        [Required]
        public string _password;

        public ForgotPasswordObject(string un, string pw) { _username = un; _password = pw; }
    }
}

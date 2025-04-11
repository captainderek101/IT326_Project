using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class UserObject
    {
        public string? UserName { get; set; }

        public int? UserId { get; set; }
        public string? PassWord { get; set; }

        public UserObject(string name, string pw)
        {
            UserName = name;
            PassWord = pw;
        }

        public bool validateLogin() //returns true if both the username and password fields are populated
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(PassWord))
            {
                return false;
            }
            return true;
        }
    }
}

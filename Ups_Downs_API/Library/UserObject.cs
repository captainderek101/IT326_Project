using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class UserObject
    {
        private string? UserName { get; set; }

        private int? UserId { get; set; }
        private string? PassWord { get; set; }

        public UserObject(string name, string pw)
        {
            UserName = name;
            PassWord = pw;
        }

        public bool validateLogin() //returns true if there is a username and password saved
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(PassWord))
            {
                return false;
            }
            return true;
        }
    }
}

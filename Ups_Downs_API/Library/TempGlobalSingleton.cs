using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class TempGlobalSingleton
    {
        private readonly Dictionary<string, UserObject> usersByPassword = new();

        public bool AddUser(UserObject user)
        {
            if (usersByPassword.ContainsKey(user.PassWord + user.UserName))
            {
                return false; // User already exists
            }
            usersByPassword[user.PassWord + user.UserName] = user;
            Console.WriteLine("Added User!");
            return true; // User added successfully
        }

        public UserObject? GetUser(UserObject user)
        {
            if (usersByPassword.ContainsKey(user.PassWord + user.UserName))
            {
                return usersByPassword[user.PassWord + user.UserName]; // found user
            }
            return null; //user does not exist
        }
    }
}

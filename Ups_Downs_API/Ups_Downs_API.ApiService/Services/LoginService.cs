using Library;
using Microsoft.AspNetCore.Mvc;

namespace Ups_Downs_API.ApiService.Services
{
    public class LoginService
    {
        //private readonly DbContext
        public User ProcessLoginPost(LoginRequest obj)
        {
            User user = new User("username", "password", "email");
            //TODO: database connection

            return user;
        }

        public bool ProcessAccountCreationPost(CreateAccountObject obj)
        {
            // TODO: DB connection here

            return true; //account was created
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

using Library;
using Microsoft.AspNetCore.Identity;

namespace Ups_Downs_API.ApiService.Services
{
    public class LoginService
    {
        private readonly TempGlobalSingleton _TempDB;//remove later, temporary database
        public object ProcessLoginPost(UserObject obj)
        {
            Console.WriteLine("Recieved Login Request in Service");
            //temporary database connection logic
            UserObject? tempUser = _TempDB.GetUser(obj);

            return tempUser;
        }

        public bool ProcessAccountCreationPost(UserObject obj)
        {
            // TODO: DB connection here

            return true;
        }

        public void ProcessForgotPwPost(UserObject obj)
        {
            // TODO: DB connection here
        }
    }
}

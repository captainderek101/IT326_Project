using Library;

namespace Ups_Downs_API.ApiService.Services
{
    public class LoginService
    {
        public object ProcessLoginGet(UserObject obj)
        {
            // TODO: DB connection here
            //obj.UserName = "success";
            //obj.Password = "double success";


            //var v = new
            //{
            //    Name = obj.Name,
            //    Password = obj.Password
            //};

            return obj;
        }
        public void ProcessLoginPost(UserObject obj)
        {
            // TODO: DB connection here
        }

        public void ProcessAccountCreationPost(UserObject obj)
        {
            // TODO: DB connection here
        }

        public void ProcessForgotPwPost(UserObject obj)
        {
            // TODO: DB connection here
        }
    }
}

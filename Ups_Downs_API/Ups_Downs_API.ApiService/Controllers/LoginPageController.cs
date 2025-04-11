using Microsoft.AspNetCore.Mvc;
using Library;
using Ups_Downs_API.ApiService.Services;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginPageController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginPageController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public ActionResult<string> recieveLoginRequest([FromBody] UserObject userLoginAttempt)
        {
            Console.WriteLine("Recieved Login Request in Controller");
            //validating the model, if model is invalid send a BadRequest
            if (userLoginAttempt.validateLogin())
            {
                return BadRequest("Missing Requirments");
            }

            //service logic
            _loginService.ProcessLoginPost(userLoginAttempt);

            return Ok("successful login");
        }

        [HttpGet]
        public ActionResult<UserObject> returnObject()
        {
            Console.WriteLine("Recieved get Request from login page");

            UserObject user = new UserObject("nammme", "passssword");
            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult recieveAccountCreationRequest([FromBody] UserObject accountCreationRequest)
        {
            //validating the model, if model is invalid send a BadRequest
            if (accountCreationRequest.validateLogin())
            {
                return BadRequest("Missing Requirments");
            }

            //service logic
            _loginService.ProcessAccountCreationPost(accountCreationRequest);

            return Created();
        }

        [HttpPost("forgotpw")]
        public IActionResult recieveForgotPwRequest([FromBody] UserObject receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            _loginService.ProcessForgotPwPost(receivedObject);

            return Ok();
        }
    }
}

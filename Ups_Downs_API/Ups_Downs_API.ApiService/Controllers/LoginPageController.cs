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
        public ActionResult<User> recieveLoginPostRequest([FromBody] LoginRequest userLoginAttempt)
        {
            Console.WriteLine("");
            Console.WriteLine("HTTP POST request recieved to Log into account");
            //validating the model, if model is invalid send a BadRequest
            if (!ModelState.IsValid)
                return BadRequest("Missing Requirments");

            //service logic
            User user = _loginService.ProcessLoginPost(userLoginAttempt);

            if (user == null)
                return Unauthorized("Invalid username or password");

            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult recieveAccountCreationPostRequest([FromBody] CreateAccountObject accountCreationRequest)
        {
            Console.WriteLine("");
            Console.WriteLine("HTTP POST request recieved to create an account");
            //validating the model, if model is invalid send a BadRequest
            if (!ModelState.IsValid)
                return BadRequest("Missing Requirments");

            //service logic
            if (!_loginService.ProcessAccountCreationPost(accountCreationRequest))
                return StatusCode(500, "Account already Exists");

            return Created();
        }

        [HttpPost("forgotpw")]
        public IActionResult recieveForgotPwPostRequest([FromBody] ForgotPasswordObject receivedObject)
        {
            Console.WriteLine("");
            Console.WriteLine("HTTP POST request recieved to change a forgotten password");
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //service logic
            _loginService.ProcessForgotPwPost(receivedObject);

            return Ok();
        }

        [HttpPost("update")]
        public ActionResult<User> recieveUpdateAccountPostRequest([FromBody] User receivedObject)
        {
            Console.WriteLine("");
            Console.WriteLine("HTTP POST request recieved to update an account");
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Console.WriteLine("Model is valid");
            //service logic
            var updatedUser = _loginService.ProcessUpdateAccountPost(receivedObject);

            return Ok(updatedUser);
        }

        [HttpPost("validate")]
        public IActionResult recieveEmailValidationPostRequest([FromBody] User receivedObject)
        {
            Console.WriteLine("");
            Console.WriteLine("HTTP POST request recieved to validate an account");
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //service logic
            if (!_loginService.ProcessEmailValidationPost(receivedObject))
                return StatusCode(500, "");

            return Ok();
        }
    }
}

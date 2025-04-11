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
        public IActionResult recieveLoginRequest([FromBody] UserObject receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (receivedObject.validateLogin())
            {
                return BadRequest("Missing Requirments");
            }

            //service logic
            _loginService.ProcessLoginPost(receivedObject);

            return Ok();
        }

        [HttpGet("create")]
        public IActionResult recieveAccountCreationRequest([FromBody] UserObject receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            _loginService.ProcessAccountCreationPost(receivedObject);

            return Created();
        }

        [HttpGet("forgotpw")]
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

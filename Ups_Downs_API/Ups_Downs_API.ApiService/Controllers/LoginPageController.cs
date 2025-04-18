﻿using Microsoft.AspNetCore.Mvc;
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
        public ActionResult recieveLoginPostRequest([FromBody] LoginRequest userLoginAttempt)
        {
            //validating the model, if model is invalid send a BadRequest
            if (!ModelState.IsValid)
                return BadRequest("Missing Requirments");

            //service logic
            User user = _loginService.ProcessLoginPost(userLoginAttempt);

            if (user == null)
                return StatusCode(500, "Bad Login");

            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult recieveAccountCreationPostRequest([FromBody] CreateAccountObject accountCreationRequest)
        {
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
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //service logic
            _loginService.ProcessForgotPwPost(receivedObject);

            return Ok();
        }

        [HttpPost("update")]
        public IActionResult recieveUpdateAccountPostRequest([FromBody] User receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //service logic
            _loginService.ProcessUpdateAccountPost(receivedObject);

            return Ok();
        }

        [HttpPost("validate")]
        public IActionResult recieveEmailValidationPostRequest([FromBody] User receivedObject)
        {
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

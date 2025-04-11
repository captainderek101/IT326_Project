using Microsoft.AspNetCore.Mvc;
using Library;
using Ups_Downs_API.ApiService.Services;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    [Route("counter")]
    public class CounterController : ControllerBase
    {

        private readonly LoginService _loginService;

        public CounterController(LoginService loginService)
        {
            _loginService = loginService;
        }
        // This will now respond to GET requests from/counter: https://localhost:7466/counter
        [HttpGet]
        public IActionResult Get()
        {
            //retrieve databse info

            //TODO: validate model state
            
            return Ok(new UserObject("un", "pw"));
        }


        //post request accessed from https://localhost:7466/post
        [HttpPost]
        public IActionResult Post([FromBody] Library.PostObject receivedObject)
        {

            if (receivedObject == null || string.IsNullOrWhiteSpace(receivedObject.Content))
            {
                return BadRequest("Invalid object received.");
            }

            Console.WriteLine(receivedObject.Content);

            return Ok($"Received: {receivedObject.Content}");
        }
    }
}
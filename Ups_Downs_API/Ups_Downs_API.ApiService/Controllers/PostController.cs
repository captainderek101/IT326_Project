using Microsoft.AspNetCore.Mvc;

using Library;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    public class CounterController : ControllerBase
    {
        // This will now respond to GET requests from/counter: https://localhost:7466/counter
        [HttpGet("/counter")]
        public IActionResult Get()
        {
            //retrieve databse info

            //TODO: validate model state
            
            return Ok("GET request received from Counter button!!!!!");
        }


        //post request accessed from https://localhost:7466/post
        [HttpPost("/counter")]
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


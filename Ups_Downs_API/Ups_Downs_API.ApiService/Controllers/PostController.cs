using Microsoft.AspNetCore.Mvc;

namespace Ups_Downs_API.ApiService.Controllers
{
    // Route is now the root "/"
    [Route("/")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        // This will now respond to GET requests at the root: https://localhost:7466
        [HttpGet("/counter")]
        public IActionResult Get()
        {
            return Ok("GET request received from Counter button!!!!!");
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Library;
using Ups_Downs_API.ApiService.Services;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    [Route("browse")]
    public class BrowseController : ControllerBase
    {
        private readonly BrowseService _BrowseService;

        public BrowseController(BrowseService browseService)
        {
            _BrowseService = browseService;
        }

        [HttpGet]
        public ActionResult<List<Post>> recieveBrowseRequest([FromBody] string filter)
        {
            Console.WriteLine("Recieved Browse Request in Controller");
            //validating the model, if model is invalid send a BadRequest
            
            //return BadRequest("Missing Requirments");

            //service logic
            _BrowseService.ProcessBrowse(filter);

            return Ok("successful Browse");
        }
    }
}

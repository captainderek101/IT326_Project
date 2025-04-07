using Microsoft.AspNetCore.Mvc;

using Library;
using Ups_Downs_API.ApiService.Services;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    [Route("skeleton")]//remove "skeleton" and rename to the page you want the api calls to come from
    //example: https://localhost:7466/skeleton is the end point currently
    public class SkeletonController : ControllerBase //remove SkeletonController and rename to the *pagename*Controller
    {

        private readonly SkeletonService _skeletonService;

        // Constructor Injection
        public SkeletonController(SkeletonService skeletonService)
        {
            _skeletonService = skeletonService;
        }

        [HttpGet]//if page has several different types of get or post requests you can use [HttpGet("Skeleton")]
        public ActionResult<SkeletonObject> someGet()//remove SkeletonObject from ActionResult<SkeletonObject> and rename with the actually object to return
        {
            var obj = new SkeletonObject();//replace with actual object you are passing
            //Logic for service file connection

            if (!ModelState.IsValid)
            {

            }


            //this return is an ActionResult object that is created with the ok() method
            //use this to return the object you want and the status code
            //other ActionResult methods incase you need different return types
            //NotFound() gives a 404 not found
            //BadRequest() gives a 400 message
            //StatusCode(500) for generic server side error that does not return an object
            return Ok(obj);//returns status code 200 and the object for retrieval
        }

        [HttpGet]
        public ActionResult<SkeletonObject> someTestGet([FromQuery] SkeletonObject receivedObject)
        {
        // [FromQuery] - If I understand this right, the FromQuery will bind
        // the query parameters from a given HTTP Request to the method parameters, in this case our SkeletonObject

        /* For example, [FromQuery] DateTime startDate, [FromQuery] 
                DateTime endDate binds the query parameters(startDate and endDate ) 
                from an HTTP GET request to the respective method parameters */


            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            _skeletonService.ProcessSkeletonGet(receivedObject);

            return Ok(receivedObject);
        }

        [HttpPost]
        public IActionResult somePost([FromBody] Library.SkeletonObject receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            _skeletonService.ProcessSkeletonPost(receivedObject);

            //return created() if you are creating a new database entry and it was successful
            return Created();//returns status code 201 for success on saving the recieved object to the database
        }

    }
}

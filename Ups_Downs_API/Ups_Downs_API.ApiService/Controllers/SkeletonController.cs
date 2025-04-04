using Microsoft.AspNetCore.Mvc;

using Library;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    [Route("skeleton")]//remove "skeleton" and rename to the page you want the api calls to come from
    //example: https://localhost:7466/skeleton is the end point currently
    public class SkeletonController : ControllerBase //remove SkeletonController and rename to the *pagename*Controller
    {
        [HttpGet]//if page has several different types of get or post requests you can use [HttpGet("Skeleton")]
        public ActionResult<SkeletonObject> Get()//remove SkeletonObject from ActionResult<SkeletonObject> and rename with the actually object to return
        {
            var obj = new SkeletonObject();//replace with actual object you are passing
            //Logic for service file connection




            //this return is an ActionResult object that is created with the ok() method
            //use this to return the object you want and the status code
            //other ActionResult methods incase you need different return types
            //NotFound() gives a 404 not found
            //BadRequest() gives a 400 message
            //StatusCode(500) for generic server side error that does not return an object
            return Ok(obj);//returns status code 200 and the object for retrieval
        }

        [HttpPost]
        public IActionResult Post([FromBody] Library.SkeletonObject receivedObject)
        {
            //logic for service file connection

            //return created() if you are creating a new database entry and it was successful
            return Created();//returns status code 201 for success on saving the recieved object to the database
        }

    }
}

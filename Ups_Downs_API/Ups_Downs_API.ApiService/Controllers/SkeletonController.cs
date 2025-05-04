//using Microsoft.AspNetCore.Mvc;
//using Library;
//using Ups_Downs_API.ApiService.Services;

//namespace Ups_Downs_API.ApiService.Controllers
//{
//    [ApiController]
//    [Route("skeleton")]//remove "skeleton" and rename to the page you want the api calls to come from
//    //example: https://localhost:7466/skeleton is the end point currently, if we want to call a specific endpoint do https://localhost:7466/skeleton/test
//    public class SkeletonController : ControllerBase //remove SkeletonController and rename to the *pagename*Controller
//    {

//        private readonly SkeletonService _skeletonService;

//        // Constructor Injection
//        public SkeletonController(SkeletonService skeletonService)
//        {
//            _skeletonService = skeletonService;
//        }

//        [HttpGet("test")] //if page has different types of GET or POST requests we need to diversify the call like this
//        public ActionResult<SkeletonObject> someTestGet([FromQuery] SkeletonObject receivedObject)
//        // <...? is our expected return value, replace with the object class we need
//        // [FromQuery] - FromQuery will bind URL parameters from a HTTP Request to the method parameters
//        {
//            //validating the model, if model is not valid send a BadRequest - which is 400 and send what the issue was
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            //service logic - sends object to method in service.
//            var test = _skeletonService.ProcessSkeletonGet(receivedObject);

//            // this will return status code 200 and the object for retrieval
//            return Ok(test);
//        }

//        [HttpPost]
//        public IActionResult somePost([FromBody] SkeletonObject receivedObject)
//        {
//            //logic for service file connection
//            //validating the model, if model is not valid send a BadRequest
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            //service logic
//            _skeletonService.ProcessSkeletonPost(receivedObject);

//            //return created() if you are creating a new database entry and it was successful
//            return Created();//returns status code 201 for success on saving the recieved object to the database
//        }

//    }
//}

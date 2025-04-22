using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Ups_Downs_API.ApiService.Services;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    [Route("creatingPost")]
    public class CreatingPostController : ControllerBase
    {

        private readonly CreatingPostService _creatingPostService;

        public CreatingPostController(CreatingPostService creatingPostService)
        {
            _creatingPostService = creatingPostService;
        }

        [HttpPost("Creation")]
        public IActionResult SomePost([FromBody] CreatingPostObject receivedObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            var createdPost = _creatingPostService.ProcessCreatingPost(receivedObject);

            return Created($"/creatingPost/{createdPost.PostId}", createdPost);
        }
    }
}


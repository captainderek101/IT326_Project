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
        public ActionResult<List<PostObject>> requestPosts([FromQuery(Name = "filterType")] string filterType, [FromQuery(Name = "filterValue")] string filterValue)
        {
            //validating the model, if model is invalid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            var postList = _BrowseService.ProcessBrowse(filterType, filterValue);

            return Ok(postList);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Library;
using Ups_Downs_API.ApiService.Services;
using System.Globalization;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    [Route("")]
    public class HomePageController : ControllerBase
    {
        private readonly HomePageService _HomePageService;
        private CurrentEvents _CurrentEvents;

        public HomePageController(HomePageService homePageService)
        {
            _HomePageService = homePageService;
        }

        [HttpGet]
        public ActionResult<CurrentEvents> getCurrentEvents()
        {
            //validating the model, if model is invalid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            CurrentEvents currentEvents = _HomePageService.getCurrentEvents();

            return Ok(currentEvents);
        }
    }
}

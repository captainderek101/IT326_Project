using Microsoft.AspNetCore.Mvc;
using Library;
using Ups_Downs_API.ApiService.Services;
using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Database;
using Microsoft.Data.SqlClient;
using System.Data;
using static Azure.Core.HttpHeader;

namespace Ups_Downs_API.ApiService.Controllers
{
    [ApiController]
    [Route("view")]
    public class ViewPostController : ControllerBase
    {
        private readonly ViewPostService _viewPostService;

        // Constructor Injection
        public ViewPostController(ViewPostService viewPostService)
        {
            _viewPostService = viewPostService;
        }

        [HttpGet(Name = "view")]
        public ActionResult<PostObject> retrievePost_GET([FromQuery(Name = "id")] int postID = 1)
        // [FromQuery] - FromQuery will bind URL parameters from a HTTP Request to the method parameters
        {
            //validating the model, if model is not valid send a BadRequest - which is 400 and send what the issue was
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic - sends object to method in service.
            var retrievedPost = _viewPostService.GetPost(postID);

            // this will return status code 200 and the object for retrieval
            return Ok(retrievedPost);
        }

        [HttpGet("comments", Name = "comments")]
        public ActionResult<List<CommentObject>> retrieveCommentsForPost_GET([FromQuery(Name = "id")] int postID = 1)
        // [FromQuery] - FromQuery will bind URL parameters from a HTTP Request to the method parameters
        {
            //validating the model, if model is not valid send a BadRequest - which is 400 and send what the issue was
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic - sends object to method in service.
            var retrievedComments = _viewPostService.GetComments(postID);

            // this will return status code 200 and the object for retrieval
            return Ok(retrievedComments);
        }

        [HttpPost("report", Name = "report")]
        public IActionResult reportPost_POST([FromBody] ReportRequest receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            var createdReport = _viewPostService.PostReport(receivedObject);

            //return created() if you are creating a new database entry and it was successful
            return Created($"/view/{createdReport.PostID}", createdReport);//returns status code 201 for success on saving the recieved object to the database
        }

        [HttpPut("vote", Name = "vote")]
        public IActionResult voteOnPost_PUT([FromBody] VoteRequest receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            var createdVote = _viewPostService.PutVote(receivedObject);

            //return created() if you are creating a new database entry and it was successful
            return Created($"/view/{createdVote.PostID}", createdVote);//returns status code 201 for success on saving the recieved object to the database
        }

        [HttpPost("comment", Name = "comment")]
        public IActionResult commentOnPost_POST([FromBody] CommentObject receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            var createdComment = _viewPostService.PostComment(receivedObject);

            //return created() if you are creating a new database entry and it was successful
            return Created($"/view/{createdComment.PostID}", createdComment);//returns status code 201 for success on saving the recieved object to the database
        }

        [HttpPost("subscribe", Name = "subscribe")]
        public IActionResult subscribeToPost_POST([FromBody] SubscriptionRequest receivedObject)
        {
            //logic for service file connection
            //validating the model, if model is not valid send a BadRequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //service logic
            var createdSubscription = _viewPostService.PostSubscribe(receivedObject);

            //return created() if you are creating a new database entry and it was successful
            return Created($"/view/{createdSubscription.PostID}", createdSubscription);//returns status code 201 for success on saving the recieved object to the database
        }

    }
}

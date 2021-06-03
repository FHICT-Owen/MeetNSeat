using MeetNSeat.Logic;
using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IManageFeedback _manageFeedback;
        public FeedbackController(IManageFeedback manageFeedback)
        {
            _manageFeedback = manageFeedback;
        }
        
        [HttpGet("{id}")]
        public ActionResult GetAllFeedback(string id)
        {
            var allFeedback = _manageFeedback.GetFeedbackByUser(id);
            return Ok(allFeedback);
        }
        
        [HttpPost]
        public void AddFeedback([FromBody] FeedbackModel feedbackModel)
        {
            var newFeedback = new Feedback(feedbackModel.Description, feedbackModel.FeedbackState, feedbackModel.UserId);
            _manageFeedback.AddFeedback(newFeedback);
        }
    }
}

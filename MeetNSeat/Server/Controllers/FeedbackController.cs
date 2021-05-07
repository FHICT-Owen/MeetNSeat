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
        [HttpGet]
        public ActionResult GetAllIssues()
        {
            var issues = _manageFeedback.GetAllFeedback();
            return Ok(issues);
        }
    }
}

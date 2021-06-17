using System;
using MeetNSeat.Logic;
using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    public class FeedbackController : ApiControllerBase
    {
        private readonly IManageFeedback _manageFeedback;
        public FeedbackController(IManageFeedback manageFeedback)
        {
            _manageFeedback = manageFeedback;
        }

        [HttpGet]
        public ActionResult GetAllUsersWithFeedback()
        {
            try
            {
                var allUsers = _manageFeedback.GetAllUsersWithFeedback();
                return allUsers == null ? Problem() : Ok(allUsers);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetAllFeedback(string id)
        {
            try
            {
                var allFeedback = _manageFeedback.GetFeedbackByUser(id);
                return allFeedback == null ? Problem() : Ok(allFeedback);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpPost]
        public ActionResult AddFeedback([FromBody] FeedbackModel feedbackModel)
        {
            var newFeedback = new Feedback(feedbackModel.Description, feedbackModel.FeedbackState, feedbackModel.UserId);
            return Ok(_manageFeedback.AddFeedback(newFeedback));
        }
    }
}

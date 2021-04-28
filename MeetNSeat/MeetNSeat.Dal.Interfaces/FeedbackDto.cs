using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Dal.Interfaces
{
    public class FeedbackDto
    {
        public int FeedbackID { get;  set; }
        public string Description { get;  set; }
        public int FeedbackState { get;  set; }

        public FeedbackDto(int feedbackId, string description, int feedbackState)
        {
            FeedbackID = feedbackId;
            Description = description;
            FeedbackState = feedbackState;
        }
    }
}

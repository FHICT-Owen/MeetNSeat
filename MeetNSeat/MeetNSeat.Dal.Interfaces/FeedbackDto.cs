using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Dal.Interfaces
{
    public class FeedbackDto
    {
        public int Id { get;  set; }
        public string Description { get;  set; }
        public int FeedbackState { get;  set; }

        public FeedbackDto(int id, string description, int feedbackState)
        {
            Id = id;
            Description = description;
            FeedbackState = feedbackState;
        }
    }
}

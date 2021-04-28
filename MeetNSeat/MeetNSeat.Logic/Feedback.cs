using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Logic
{
    public class Feedback
    {
        //TODO: iFeedbackDal?
        public int FeedbackID { get; private set; }
        public string Description { get; private set; }
        public int FeedbackState { get; private set; }

        public Feedback(int feedbackID, string description, int feedbackState)
        {
            FeedbackID = feedbackID;
            Description = description;
            FeedbackState = feedbackState;
        }

    }
}

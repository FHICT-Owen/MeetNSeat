using System;
using System.Collections.Generic;
using System.Text;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class FeedbackCollection : IManageFeedback
    {
        private readonly List<Feedback> _feedback = new List<Feedback>();
        private readonly IFeedbackDal _dal;

        public FeedbackCollection()
        {
            _dal = FeedbackFactory.CreateFeedbackDal();
        }
        public IReadOnlyCollection<Feedback> GetAllFeedback()
        {
            _feedback.Clear();
            _dal.GetAllFeedback().ForEach(
                dto => _feedback.Add(new  Feedback(dto)));
            return _feedback.AsReadOnly();
        }
    }
}

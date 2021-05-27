using System.Collections.Generic;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class FeedbackCollection : IManageFeedback
    {
        private readonly List<Feedback> _feedback = new ();
        private readonly IFeedbackDal _dal;
        private readonly IReservationDal _dalReservationDal;

        public FeedbackCollection()
        {
            _dal = FeedbackFactory.CreateFeedbackDal();
            _dalReservationDal = ReservationFactory.CreateReservationDal();
        }

        public bool AddFeedback(Feedback feedback)
        {
            return _dal.InsertFeedback(feedback.ConvertToDto());
        }

        public IReadOnlyCollection<Feedback> GetAllFeedback()
        {
            _feedback.Clear();
            _dal.GetAllFeedback().ForEach(
                dto => _feedback.Add(new  Feedback(dto)));
            return _feedback.AsReadOnly();
        }
        
        public List<FeedbackDto> GetFeedbackByUser(string userId)
        {
            FeedbackDal feedbackDal = new FeedbackDal();
            List<FeedbackDto> feedbackDto = new List<FeedbackDto>();

            if (feedbackDal.GetFeedbackDtoByUserId(userId) != null)
            {
                feedbackDto = feedbackDal.GetFeedbackDtoByUserId(userId);
            }
            

        //_dalReservationDal.GetReservationByUser(userId).ForEach(r => feedbackDto.Add(feedbackDal.GetFeedbackDtoById(r.FeedbackId)));
            return feedbackDto;
        }
    }
}

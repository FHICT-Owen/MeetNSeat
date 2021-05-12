using System;
using System.Collections.Generic;
using System.Text;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class FeedbackCollection : IManageFeedback
    {
        private readonly List<Feedback> _feedback = new List<Feedback>();
        private readonly IFeedbackDal _dal;
        private readonly IReservationDal dalReservationDal;


        public FeedbackCollection()
        {
            _dal = FeedbackFactory.CreateFeedbackDal();
            dalReservationDal = ReservationFactory.CreateReservationDal();
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
            dalReservationDal.GetReservationByUser(userId).ForEach(r =>
               feedbackDto.Add(feedbackDal.GetFeedbackDtoById(r.FeedbackId))
           );
            return feedbackDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MeetNSeat.Dal;
namespace MeetNSeat.Dal.Interfaces
{
    public interface IFeedbackDal
    {
        List<FeedbackDto> GetAllFeedback();
        FeedbackDto GetFeedbackDtoById(int id);
        bool InsertFeedback(FeedbackDto feedbackDto);
        bool UpdateFeedback(FeedbackDto feedbackDto);
        bool DeleteFeedback(int id);
    }
}

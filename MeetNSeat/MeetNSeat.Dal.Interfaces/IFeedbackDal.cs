using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IFeedbackDal
    {
        List<FeedbackDto> GetAllFeedback();
        List<UserScoreDto> GetAllUsersWithFeedback();
        List<FeedbackDto> GetFeedbackDtoByUserId(string userId);
        bool InsertFeedback(FeedbackDto feedbackDto);
        bool UpdateFeedback(FeedbackDto feedbackDto);
        bool DeleteFeedback(int id);

    }
}

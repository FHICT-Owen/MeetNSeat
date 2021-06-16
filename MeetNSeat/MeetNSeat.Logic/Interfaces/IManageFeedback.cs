using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFeedback
    {
        IReadOnlyCollection<Feedback> GetAllFeedback();
        List<FeedbackDto> GetFeedbackByUser(string userId);
        List<UserScore> GetAllUsersWithFeedback();
        bool AddFeedback(Feedback feedback);
    }
}

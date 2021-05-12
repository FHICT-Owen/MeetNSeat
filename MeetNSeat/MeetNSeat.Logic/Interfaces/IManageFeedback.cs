using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFeedback
    {
        IReadOnlyCollection<Feedback> GetAllFeedback();
        List<FeedbackDto> GetFeedbackByUser(string userId);
        bool AddFeedback(Feedback feedback);
    }
}

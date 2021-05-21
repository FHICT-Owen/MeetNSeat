using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFeedback
    {
        IReadOnlyCollection<Feedback> GetAllFeedback();
        IReadOnlyCollection<Feedback> GetFeedbackByUser(string userId);
        bool AddFeedback(Feedback feedback);
    }
}

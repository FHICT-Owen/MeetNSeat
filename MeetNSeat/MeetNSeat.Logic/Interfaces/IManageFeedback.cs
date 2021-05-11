using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFeedback
    {
        IReadOnlyCollection<Feedback> GetAllFeedback();
    }
}

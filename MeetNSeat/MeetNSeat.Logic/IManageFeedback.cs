using System.Collections.Generic;
namespace MeetNSeat.Logic
{
    public interface IManageFeedback
    {
        IReadOnlyCollection<Feedback> GetAllFeedback();
    }
}

﻿using System.Collections.Generic;
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

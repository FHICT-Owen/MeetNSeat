using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IUserDal
    {
        List<FeedbackDto> GetFeedbackByUser(string id);
        void AddNewUser(UserDto userDto);
        List<UserDto> GetAllUsers();
    }
}

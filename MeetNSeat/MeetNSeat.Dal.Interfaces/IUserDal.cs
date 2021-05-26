using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IUserDal
    {
        List<FeedbackDto> GetFeedbackByUser(string id);
        void AddNewUser(UserDto userDto);
        int CheckRole(string id);
        List<UserDto> GetAllUsers();
    }
}

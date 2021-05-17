using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageAuthentication
    {
        List<User> GetAllUsers();
        void AddUserIfNonExistent(User newUser);
    }
}
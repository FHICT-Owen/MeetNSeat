using System.Collections.Generic;
using System.IO;
using System.Linq;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public class Authentication
    {
        private readonly List<User> _users = new List<User>();
        private readonly IUserDal _dal;
        
        public Authentication()
        {
            _dal = UserFactory.CreateUserDal();
        }
        
        // private IReadOnlyList<User> GetAllUsers() 
        // {
        //     _users.Clear();
        //
        //     _dal.GetAllUsers().ForEach(
        //         dto => _users.Add(new User(dto)));
        //     return _users.
        // }
        //
        // public bool CheckIfUserExist(string userId)
        // {
        //     _dal.GetAllUsers().SingleOrDefault(user => user.Id == userId);
        //     return
        // }
        //
        // public void AddUser(string userId)
        // {
        //     var exists = _dal.GetAllUsers();
        //     _dal.AddNewUser(User.ConvertToDto());
        // }
    }
}
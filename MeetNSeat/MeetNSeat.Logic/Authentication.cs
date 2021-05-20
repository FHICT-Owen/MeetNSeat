using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class Authentication : IManageAuthentication
    {
        private readonly List<User> _users = new List<User>();
        private readonly IUserDal _dal;
        
        public Authentication()
        {
            _dal = UserFactory.CreateUserDal();
        }
        
        public List<User> GetAllUsers() 
        {
            _dal.GetAllUsers().ForEach(
                dto => _users.Add(new User(dto)));
            
            return _users;
        }
        
        public void AddUserIfNonExistent(User newUser)
        {
            var exists = _users.Exists(user => user.Id == newUser.Id);
            if (exists) return;
            _dal.AddNewUser(newUser.ConvertToDto());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class Authentication
    {
        private static Authentication _instance;
        private static readonly object Padlock = new();
        private readonly List<User> _users = new ();
        private readonly IUserDal _dal;
        
        public Authentication()
        {
            _dal = UserFactory.CreateUserDal();
        }

        public static Authentication Instance
        {
            get
            {
                lock (Padlock)
                {
                    // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
                    if (_instance == null)
                    {
                        _instance = new Authentication();
                        _instance._dal.GetAllUsers().ForEach(
                            dto => _instance._users.Add(new User(dto)));
                    }
                    return _instance;
                }
            }
        }
        
        public List<User> GetAllUsers() 
        {
            return _users;
        }

        public User GetUser(string userId)
        {
            var user = _users.SingleOrDefault(res => res.Id == userId);
            return user;
        }
        
        public void AddUserIfNonExistent(User newUser)
        {
            var exists = _users.Exists(user => user.Id == newUser.Id);
            if (exists) return;
            _users.Add(newUser);
            _dal.AddNewUser(newUser.ConvertToDto());
        }
    }
}
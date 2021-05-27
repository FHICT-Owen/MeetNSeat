using MeetNSeat.Logic;
using MeetNSeat.Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
    [TestClass]
    public class AuthenticationUnitTests
    {
        private readonly IManageAuthentication _manageAuthentication = new Authentication();
            
        [TestMethod]
        public void UserShouldBeAddedToTheDatabase()
        {
            var newUser = new User("KOEK", "AAP", 0);
            _manageAuthentication.AddUserIfNonExistent(newUser);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            var newUser = new User("KOEK", "AAP", 0);
            
        }


    }
}
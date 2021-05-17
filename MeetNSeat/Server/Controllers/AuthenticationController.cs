using MeetNSeat.Logic;
using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IManageAuthentication _manageAuthentication;

        public AuthenticationController(IManageAuthentication manageAuthentication)
        {
            _manageAuthentication = manageAuthentication;
        }
        
        [HttpPost]
        public void AddUser([FromBody] UserModel userModel)
        {
            _manageAuthentication.GetAllUsers();
            var newUser = new User(userModel.Id, userModel.Nickname, (Role)userModel.Role);
            _manageAuthentication.AddUserIfNonExistent(newUser);
        }
    }
}
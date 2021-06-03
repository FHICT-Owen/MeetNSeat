using MeetNSeat.Logic;
using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IManageAuthentication _manageAuthentication;

        public AuthenticationController(IManageAuthentication manageAuthentication)
        {
            _manageAuthentication = manageAuthentication;
        }
        
        [HttpPost("adduser")]
        public void AddUser([FromBody] UserModel userModel)
        {
            _manageAuthentication.GetAllUsers();
            var newUser = new User(userModel.Id, userModel.Nickname, (Role)userModel.Role);
            _manageAuthentication.AddUserIfNonExistent(newUser);
        }

        [HttpGet("user{userId}")]
        public ActionResult GetUser(string userId)
        {
            var user = Authentication.Instance.GetUser(userId);
            if (user == null) return Ok(0);
            var role = (int) user.Role;
            return Ok(role);
        }
    }
}
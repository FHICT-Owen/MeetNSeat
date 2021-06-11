using MeetNSeat.Logic;
using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = Authentication.Instance.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("adduser")]
        public void AddUser([FromBody] UserModel userModel)
        {
            Authentication.Instance.GetAllUsers();
            var newUser = new User(userModel.Id, userModel.Nickname, (Role)userModel.Role);
            Authentication.Instance.AddUserIfNonExistent(newUser);
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
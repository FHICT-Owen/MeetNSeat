using System;
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
            if (users == null) return Problem();
            return Ok(users);
        }

        [HttpPost("adduser")]
        public ActionResult AddUser([FromBody] UserModel userModel)
        {
            try
            {
                Authentication.Instance.GetAllUsers();
                var newUser = new User(userModel.Id, userModel.Nickname, (Role)userModel.Role);
                Authentication.Instance.AddUserIfNonExistent(newUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public ActionResult GetUser(string userId)
        {
            try
            {
                var user = Authentication.Instance.GetUser(userId);
                if (user == null) return Problem();
                var role = (int)user.Role;
                return Ok(role);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
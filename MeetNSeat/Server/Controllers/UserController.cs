using MeetNSeat.Logic;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IManageUser _manageUser;

        public UserController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }

        [HttpGet]
        public ActionResult GetAllReservations()
        {
            var user = _manageUser.GetAllReservations();
            return Ok(user);
        }

    }
}
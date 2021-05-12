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
            var user = _manageUser.GetReservationByUser("Rik Leemans");
            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public bool DeleteResult(int id)
        {
            return _manageUser.DeleteReservation(id);
        }

    }
}
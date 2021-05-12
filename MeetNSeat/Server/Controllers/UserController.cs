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

<<<<<<< HEAD
        [HttpDelete("{id:int}")]
=======
        [HttpPost]
        public void CreateReservation([FromBody] ReservationModel reservationModel)
        {
            var newReservation = _manageUser.AddReservation(reservationModel.Type, reservationModel.LocationId, reservationModel.UserId, reservationModel.Attendees, reservationModel.StartTime, reservationModel.EndTime);
        }

        [HttpPost]
>>>>>>> 6c626a5cc3ed86aa59e73de195f5fa62b81992de
        public bool DeleteResult(int id)
        {
            return _manageUser.DeleteReservation(id);
        }

    }
}
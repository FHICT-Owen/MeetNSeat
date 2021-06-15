using System;
using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IManageUser _manageUser;

        public UserController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }

        [HttpGet("{id}")]
        public ActionResult GetUserReservations(string id)
        {
            var reservations = _manageUser.GetReservationByUser(id);
            return Ok(reservations);
        }

        

        [HttpPost]
        public void CreateReservation([FromBody] ReservationModel reservationModel)
        {
            var newReservation = _manageUser.AddReservation(reservationModel.Type,reservationModel.RoomId, reservationModel.LocationId, reservationModel.UserId, reservationModel.Attendees, reservationModel.StartTime, reservationModel.EndTime);
        }

        [HttpPost("edit")]
        public bool UpdateReservation([FromBody] ReservationModel reservation)
        {
            return _manageUser.EditReservation(reservation.ConvertToReservation());
        }

        [HttpDelete("{id:int}")]
        public bool DeleteResult(int id)
        {
            return _manageUser.DeleteReservation(id);
        }
        

        //[HttpGet]
        //public ActionResult GetAllLocations()
        //{
        //    var locations = _manageUser.GetAllLocations();
        //    return Ok(locations);
        //}

        [HttpPost("confirm{id}")]

        public ActionResult ConfirmReservation(int id, [FromBody] string ip)
        {
            Console.WriteLine(id +" "+ip);
            var confirmed = _manageUser.ConfirmReservation(id, ip);
            if (confirmed)
            {
                return Ok();
            }
            return Problem();
        }

        [HttpGet("types")]
        public ActionResult GetAllRoomTypes()
        {
            var rooms = _manageUser.GetAllRoomTypes();
            return Ok(rooms);
        }
    }
}
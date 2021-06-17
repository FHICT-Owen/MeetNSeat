using System;
using MeetNSeat.Logic;
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
        public ActionResult CreateReservation([FromBody] ReservationModel reservationModel)
        {
            return Ok(_manageUser.AddReservation(reservationModel.Type,reservationModel.RoomId, reservationModel.LocationId, reservationModel.UserId, reservationModel.Attendees, reservationModel.StartTime, reservationModel.EndTime));
        }

        [HttpPost("edit")]
        public ActionResult UpdateReservation([FromBody] ReservationModel reservation)
        {
            return Ok(_manageUser.EditReservation(reservation.ConvertToReservation()));
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteResult(int id)
        {
            return Ok(_manageUser.DeleteReservation(id));
        }

        [HttpPut("confirm/{ip}")]
        public ActionResult ConfirmReservation(string ip, [FromBody]ReservationModel reservation)
        {
            var confirmed = reservation.ConvertToReservation().ConfirmReservation(ip);
            Console.WriteLine(confirmed);
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
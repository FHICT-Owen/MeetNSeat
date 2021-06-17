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
        private readonly IManagePeriod _managePeriod;

        public UserController(IManageUser manageUser, IManagePeriod managePeriod)
        {
            _manageUser = manageUser;
            _managePeriod = managePeriod;
        }
        
        [HttpGet("{locationId}/{roomType}/{attendees}/{startTime}/{endTime}")]
        public ActionResult GetAvailableRooms(int locationId, string roomType, int attendees, DateTime startTime, DateTime endTime)
        {
            var days = _managePeriod.GetPeriods(locationId, roomType, attendees, startTime, endTime);
            return Ok(days);
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
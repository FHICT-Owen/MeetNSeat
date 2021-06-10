using System.Security.Cryptography.X509Certificates;
using MeetNSeat.Client.Models;
using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeetNSeat.Server.Controllers
{
    public class RoomController : ApiControllerBase
    {
        private readonly IManageRoom _manageRoom;
        private readonly IManageUser _manageUser;

        public RoomController(IManageRoom manageRoom, IManageUser manageUser)
        {
            _manageRoom = manageRoom;
            _manageUser = manageUser;
        }

        [HttpGet]
        public ActionResult GetAllRooms()
        {
            var rooms = _manageRoom.GetAllRooms();
            return Ok(rooms);
        }
        [HttpGet("{locationId}/{roomType}/{attendees}/{startTime}/{endTime}")]
        public ActionResult GetAvailableRooms(int locationId, string roomType, int attendees, DateTime startTime, DateTime endTime)
        {
            var rooms = _manageUser.GetAvailableRooms(locationId,roomType, attendees, startTime, endTime);

            return Ok(rooms);
        }

        [HttpPost]
        public void AddRoom([FromBody] RoomModel roomModel)
        {
            _manageRoom.AddRoom(roomModel.FloorId, roomModel.Name, roomModel.Type, roomModel.Spots, roomModel.Facilities);
        }
        
        [HttpDelete("{id:int}")]
        public void DeleteRoom(int id)
        {
            _manageRoom.DeleteRoom(id);
        }
        
        [HttpPut]
        public void UpdateRoom([FromBody] RoomModel roomModel)
        {
            _manageRoom.UpdateRoom(roomModel.Id, roomModel.Name, roomModel.Type, roomModel.Spots, roomModel.Facilities);
            var s = 0;
        }
    }
}

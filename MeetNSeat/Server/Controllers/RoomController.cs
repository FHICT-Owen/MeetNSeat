using System.Security.Cryptography.X509Certificates;
using MeetNSeat.Client.Models;
using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IManageRoom _manageRoom;

        public RoomController(IManageRoom manageRoom)
        {
            _manageRoom = manageRoom;
        }

        [HttpGet]
        public ActionResult GetAllRooms()
        {
            var rooms = _manageRoom.GetAllRooms();
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

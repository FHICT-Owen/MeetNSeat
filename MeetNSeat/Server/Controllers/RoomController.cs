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
    }
}

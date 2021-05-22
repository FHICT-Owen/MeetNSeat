using MeetNSeat.Client.Models;
using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
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

        [HttpPost]
        public void AddIssue([FromBody] RoomModel roomModel)
        {
            _manageRoom.AddRoom(roomModel.FloorId, roomModel.Name, roomModel.Type, roomModel.Spots, roomModel.Facilities);
        }
    }
}

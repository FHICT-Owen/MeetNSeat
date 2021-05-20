using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/floor")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        public int LocationId { get; set; }
        private readonly IManageFloor _manageFloor;

        public FloorController(IManageFloor manageFloor)
        {
            _manageFloor = manageFloor;
        }
        [HttpGet]
        public ActionResult GetAllFloorByLocation()
        {
            var floors = _manageFloor.GetAllFloorsByLocation(LocationId);
            return Ok(floors);
        }

        [HttpPost]
        public void GetLocationId(int locationId)
        {
            LocationId = locationId;
        }

    }
}

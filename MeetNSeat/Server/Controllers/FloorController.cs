using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/floor")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IManageFloor _manageFloor;

        public FloorController(IManageFloor manageFloor)
        {
            _manageFloor = manageFloor;
        }
        //[HttpGet]
        //public ActionResult GetAllFloorByLocation()
        //{
        //    var floors = _manageFloor.GetAllFloorsByLocation();
        //    return Ok(floors);
        //}

    }
}

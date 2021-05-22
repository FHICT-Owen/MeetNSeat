using System.Threading.Tasks;
using Blazored.SessionStorage;
using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/floor")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IManageFloor _manageFloor;
        private readonly ISessionStorageService _sessionStorageService;

        public FloorController(IManageFloor manageFloor, ISessionStorageService sessionStorageService)
        {
            _manageFloor = manageFloor;
            _sessionStorageService = sessionStorageService;
        }
        
        [HttpGet("{id:int}")]
        public ActionResult GetAllFloorByLocation(int id)
        {
            var floors = _manageFloor.GetAllRoomsAndFloorByLocationId(id);
            return Ok(floors);
        }
    }
}

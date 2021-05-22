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
        private int LocationId { get; set; } //This wont work
        private readonly IManageFloor _manageFloor;
        private readonly ISessionStorageService _sessionStorageService;

        public FloorController(IManageFloor manageFloor, ISessionStorageService sessionStorageService)
        {
            _manageFloor = manageFloor;
            _sessionStorageService = sessionStorageService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllFloorByLocation()
        {
            var id = await _sessionStorageService.GetItemAsync<int>("Id");
            var floors = _manageFloor.GetAllRoomsAndFloorByLocationId(id);
            return Ok(floors);
        }

        [HttpPost]
        public void GetLocationId(int locationId)
        {
            _sessionStorageService.SetItemAsync("Id", locationId);
        }

    }
}

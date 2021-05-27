using MeetNSeat.Server.Models;
using Blazored.SessionStorage;
using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

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

        [HttpGet]
        public ActionResult GetAllFloors()
        {
            var floors = _manageFloor.GetAllFloors();
            return Ok(floors);
        }


        [HttpPost]
        public void AddFloor([FromBody] FloorModel floorModel)
        {
            _manageFloor.AddFloor(floorModel.LocationId, floorModel.Name);
        }
        
        [HttpDelete("{id:int}")]
        public void DeleteFloor(int id)
        {
            _manageFloor.DeleteFloor(id);
        }
        
        [HttpPut]
        public void UpdateLocation([FromBody] FloorModel floorModel)
        {
            _manageFloor.UpdateFloor(floorModel.Id, floorModel.LocationId, floorModel.Name);
        }
    }
}

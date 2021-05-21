using MeetNSeat.Client.Models;
using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IManageLocation _manageLocation;

        public LocationController(IManageLocation manageLocation)
        {
            _manageLocation = manageLocation;
        }
		
        [HttpGet]
        public ActionResult GetAllLocations()
        {
            var locations = _manageLocation.GetAllLocations();
            return Ok(locations);
        }
        
        [HttpPost]
        public void AddLocation([FromBody] LocationModel locationModel)
        {
            _manageLocation.AddLocation(locationModel.Id, locationModel.Name, locationModel.City, locationModel.IpAddress);
        }
    }
}
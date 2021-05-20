using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    
    [Route("api/location")]
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
    }
}
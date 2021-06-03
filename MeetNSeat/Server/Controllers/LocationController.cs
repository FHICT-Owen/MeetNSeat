using MeetNSeat.Client.Models;
using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    public class LocationController : ApiControllerBase
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
        
        [HttpDelete("{id:int}")]
        public void DeleteLocation(int id)
        {
            _manageLocation.DeleteLocation(id);
        }
        
        [HttpPut]
        public void UpdateLocation([FromBody] LocationModel locationModel)
        {
            _manageLocation.UpdateLocation(locationModel.Id, locationModel.Name, locationModel.City, locationModel.IpAddress);
        }
    }
}
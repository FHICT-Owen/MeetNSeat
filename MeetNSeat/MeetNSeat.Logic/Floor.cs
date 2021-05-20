using System.Collections.Generic;
using System.Runtime.InteropServices;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class Floor
    {

        private readonly IFloorDal _dal;

        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }

        public Floor()
        {
            _dal = FloorFactory.CreateFloorDal();
        }
        
        public Floor(string name, int locationId)
        {
            Name = name;
            LocationId = locationId;
        }

        public Floor(int id, string name, int locationId)
        {
            Id = id;
            Name = name;
            LocationId = locationId;
        }

        public Floor(FloorDto floorDto)
        {
            Id = floorDto.Id;
            Name = floorDto.Name;
            LocationId = floorDto.LocationId;
        }

        public FloorDto ConvertToDto()
        {
            return new(Id, Name, LocationId);
        }
    }
}

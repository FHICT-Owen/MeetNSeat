using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Floor
    {
        private readonly IFloorDal _dal;

        public int Id { get; set; }
        public string Name { get; set; }

        public Floor()
        {
            _dal = FloorFactory.CreateFloorDal();
        }

        public IReadOnlyCollection<FloorDto> GetAllFloorsByLocation(int locationId)
        {
            return _dal.GetAllFloorsByLocation(locationId);
        }
    }
}

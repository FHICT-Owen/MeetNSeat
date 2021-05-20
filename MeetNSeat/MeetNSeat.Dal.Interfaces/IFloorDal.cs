using MeetNSeat.Dal.Interfaces.Dtos;
using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IFloorDal
    { 
        List<FloorDto> GetAllFloorsByLocation(int locationId);
        void AddFloor(FloorDto floorDto);
    }
}

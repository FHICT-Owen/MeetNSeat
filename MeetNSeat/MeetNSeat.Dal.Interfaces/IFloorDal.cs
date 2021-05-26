using MeetNSeat.Dal.Interfaces.Dtos;
using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IFloorDal
    {
        List<FloorDto> GetAllRoomsAndFloorByLocationId(int id);
        List<FloorDto> GetAllFloors();
        void AddFloor(FloorDto floorDto);
    }
}

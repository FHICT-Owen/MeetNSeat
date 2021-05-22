using MeetNSeat.Dal.Interfaces.Dtos;
using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IFloorDal
    {
        List<FloorDto> GetAllRoomsAndFloorByLocationId(int id);
        void AddFloor(FloorDto floorDto);
    }
}

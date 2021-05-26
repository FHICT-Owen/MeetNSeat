using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFloor
    {
        IReadOnlyCollection<Floor> GetAllRoomsAndFloorByLocationId(int locationId);
        IReadOnlyCollection<Floor> GetAllFloors();
        void AddFloor(int locationId, string name);
    }
}

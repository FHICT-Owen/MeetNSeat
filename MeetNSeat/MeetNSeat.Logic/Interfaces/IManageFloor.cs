using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFloor
    {
        IReadOnlyCollection<Floor> GetAllRoomsAndFloorByLocationId(int locationId);
        void AddFloor(int locationId, string name);
    }
}

using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFloor
    {
        IReadOnlyCollection<Floor> GetAllRoomsAndFloorByLocationId(int locationId);
        void AddFloor(string name, int locationId);
    }
}

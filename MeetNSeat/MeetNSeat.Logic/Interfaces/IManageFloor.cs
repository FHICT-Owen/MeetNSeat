using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFloor
    {
        IReadOnlyCollection<Floor> GetAllRoomsAndFloorByLocationId(int locationId);
        IReadOnlyCollection<Floor> GetAllFloors();
        void AddFloor(int locationId, string name);
        void DeleteFloor(int id);
        void UpdateFloor(int id, int locationId, string name);
    }
}

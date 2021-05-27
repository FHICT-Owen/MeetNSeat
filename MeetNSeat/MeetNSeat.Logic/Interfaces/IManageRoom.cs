using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageRoom
    {
        IReadOnlyCollection<Room> GetAllRooms();
        void AddRoom(int floorId, string name, string type, int spots, string facilities);
        void DeleteRoom(int id);
        void UpdateRoom(int id, string name, string type, int spots, string facilities);
    }
}

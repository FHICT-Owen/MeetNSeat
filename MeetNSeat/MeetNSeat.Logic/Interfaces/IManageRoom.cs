using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageRoom
    {
        IReadOnlyCollection<Room> GetAllIssues();
        void AddRoom(int floorId, string name, string type, int spots, string facilities);
    }
}

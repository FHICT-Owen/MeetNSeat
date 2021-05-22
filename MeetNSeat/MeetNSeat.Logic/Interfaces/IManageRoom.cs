using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageRoom
    {
        IReadOnlyCollection<Room> GetAllIssues();
        void AddRoom(int floorId, string name, string type, int spots, string facilities);
    }
}

using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageLocation
    {
        IReadOnlyCollection<Location> GetAllLocations();
        void AddLocation(Location location);
    }
}
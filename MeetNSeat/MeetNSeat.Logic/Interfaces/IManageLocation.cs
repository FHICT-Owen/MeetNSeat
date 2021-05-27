using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageLocation
    {
        IReadOnlyCollection<Location> GetAllLocations();
        void AddLocation(int id, string name, string city, string ipAddress);
        void UpdateLocation(int id, string name, string city, string ipAddress);
        void DeleteLocation(int id);
    }
}
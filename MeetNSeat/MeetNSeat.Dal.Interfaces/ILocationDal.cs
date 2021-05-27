using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal.Interfaces
{
    public interface ILocationDal
    {
        List<LocationDto> GetAllLocations();
        void AddLocation(LocationDto locationDto);
        void DeleteLocationById(int id);
        void UpdateLocation(LocationDto locationDto);
    }
}
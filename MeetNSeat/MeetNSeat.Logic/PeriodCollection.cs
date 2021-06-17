using System;
using System.Collections.Generic;
using System.Linq;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class PeriodCollection : IManagePeriod
    {
        private readonly List<Period> _periods = new ();
        private readonly IReservationDal _dal;

        public PeriodCollection()
        {
            _dal = ReservationFactory.CreateReservationDal();
        }
        
        public List<Period> GetPeriods(int locationId, string roomType, int attendees, DateTime startTime, DateTime endTime)
        {
            _periods.Clear();

            var s = _dal.GetReservationStartAndEndTimesBetweenPeriodByLocation(locationId, startTime, endTime);
            var d= GetCompleteOverlappedTimes(s);



            return _periods;
        }

        public List<TestDto> GetCompleteOverlappedTimes(List<TestDto> list)
        {
            var locationObject = new Location();
            var rooms = locationObject.GetAllRoomsWithType(roomType, locationId);
        }
        
        // var availableRooms = new List<RoomDto>();
        //     if (endTime <= startTime || startTime <= DateTime.Now || endTime <= DateTime.Now) return availableRooms;
        // var locationObject = new Location();
        // var rooms = locationObject.GetAllRoomsWithType(roomType, locationId);
        // var reservationObject = new Reservation();
        // var reservations = reservationObject.GetAllReservations();
        //     foreach (var room in rooms)
        // {
        //     if (attendees > room.Spots) continue;
        //     var interferingReservations = 
        //         reservations.Where(reservation => 
        //             reservation.RoomId == room.Id && !CheckForNoOverlap(reservation.StartTime, reservation.EndTime, startTime, endTime));
        //         
        //     if (interferingReservations.Any(reservation => reservation.RoomId == room.Id))
        //     {
        //         room.IsAvailable = false;
        //     }
        //     else
        //     {
        //         room.IsAvailable = true;
        //         availableRooms.Add(room);
        //     }
        // }
        // return availableRooms;
    }
}
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetNSeat.Logic
{
    public class User : IManageUser
    {
        public int Id { get; set; }

        private List<Reservation> reservations = new List<Reservation>();
        private IReservationDal dal;

        public User()
        {
            // Factory
            dal = ReservationFactory.CreateReservationDal();
        }

        public IReadOnlyCollection<Reservation> GetAllReservations()
        {
            reservations.Clear();
            dal.GetAllReservations().ForEach(
                dto => reservations.Add(new Reservation(dto)));
            return reservations.AsReadOnly();

        }

        public List<ManageReservationDto> GetReservationByUser(string userId)
        {
            return dal.GetReservationByUser(userId);
        }

        public bool AddReservation(string type, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            var isAvailable = true;
            // Retrieve rooms by type and location
            Room roomObject = new Room();
            var rooms = roomObject.GetAvailableRooms(type, locationId);

            var roomid = 0;

            Reservation reservationObject = new Reservation();
            var reservations = reservationObject.GetAllReservations();

            //TODO: Check if any room is available on given date
            // Loop trough reservations with given room id
            // Check if there is no reservation in given start and end
            foreach (var room in rooms)
            {
                foreach (var reservation in reservations)
                {
                    if (reservation.RoomId == room.RoomID)
                    {
                        // begin < 1 < end && begin < 2 < end

                        // reservation.StartTime < startTime && startTime < reservation.EndTime && reservation.StartTime < endTime && endTime < reservation.EndTime
                        // reservation.StartTime < endTime && endTime < reservation.EndTime

                        if (reservation.StartTime < startTime && startTime < reservation.EndTime && reservation.StartTime < endTime && endTime < reservation.EndTime)
                        {
                            isAvailable = false;
                        }
                    }
                }

                roomid = room.RoomID;
            }
            if (isAvailable)
            {
                CreateReservationDto createReservationDto = new CreateReservationDto(roomid, userId, attendees, startTime, endTime);
                return dal.AddReservation(createReservationDto);
            }


            return false;
        }

        public bool DeleteReservation(int id)
        {
            return dal.RemoveReservation(id);
        }
    }
}

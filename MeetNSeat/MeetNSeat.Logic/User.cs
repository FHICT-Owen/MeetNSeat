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

            // Retrieve rooms by type and location
            Room roomObject = new Room();
            var rooms = roomObject.GetAvailableRooms(type, locationId);

            Reservation reservation = new Reservation();
            var reservations = reservation.GetAllReservations();

            //TODO: Check if any room is available on given date
            // Loop trough reservations with given room id
            // Check if there is no reservation in given start and end
            foreach (var room in rooms)
            {
                if (!reservations.Where(r => r.RoomId == room.RoomID).Any(r => startTime > r.StartTime || endTime < r.EndTime))
                {
                    return false;
                }
                else
                {
                    CreateReservationDto createReservationDto = new CreateReservationDto(room.RoomID, userId, attendees, startTime, endTime);
                    return dal.AddReservation(createReservationDto);
                }
            }
            return false;
        }

        public bool DeleteReservation(int id)
        {
            return dal.RemoveReservation(id);
        }
    }
}

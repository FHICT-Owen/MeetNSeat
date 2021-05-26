using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public enum Role
    {
        User = 0,
        FacilityManager,
        Admin
    }
    
    public class User : IManageUser
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public Role Role { get; set; }
        private readonly List<Reservation> _reservations = new List<Reservation>();
        private readonly IReservationDal _dal;

        public User(UserDto userDto)
        {
            Id = userDto.Id;
            Nickname = userDto.Nickname;
            Role = (Role)userDto.RoleId;
        }
        
        public User()
        {
            // Factory
            _dal = ReservationFactory.CreateReservationDal();
        }

        public User(string id, string nickname, Role role)
        {
            Id = id;
            Nickname = nickname;
            Role = role;
        }

        public IReadOnlyCollection<Reservation> GetAllReservations()
        {
            _reservations.Clear();
            _dal.GetAllReservations().ForEach(
                dto => _reservations.Add(new Reservation(dto)));
            return _reservations.AsReadOnly();
        }

        public IReadOnlyCollection<Room> GetAllRoomTypes()
        {
            var room = new Room();
            return room.GetRoomTypes().Select(roomDto => new Room(roomDto)).ToList();
        }

        public IReadOnlyCollection<ManageReservationDto> GetReservationByUser(string id)
        {
            return _dal.GetReservationByUser(id);
        }

        public bool AddReservation(string type, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            if (startTime < DateTime.Now || endTime < DateTime.Now) return false;
            
            var isAvailable = true;
            // Retrieve rooms by type and location
            var locationObject = new Location();
            var rooms = locationObject.GetAllRoomsWithType(type, Convert.ToInt32(locationId));
            
            var roomId = 0;

            var reservationObject = new Reservation();
            var reservations = reservationObject.GetAllReservations();

            //TODO: Check if any room is available on given date
            // Loop trough reservations with given room id
            // Check if there is no reservation in given start and end

            foreach (var room in rooms)
            {
                if (attendees <= room.Spots)
                    foreach (var reservation in reservations)
                        if (reservation.RoomId == room.Id &&
                            reservation.StartTime < startTime && startTime < reservation.EndTime ||
                            reservation.StartTime < endTime && endTime < reservation.EndTime ||
                            reservation.StartTime > startTime && endTime > reservation.EndTime) 
                            isAvailable = false;
                    
                roomId = room.Id;
            }
            if (!isAvailable) return false;

            // Convert c# format to sql format
            var sqlStartTime = Convert.ToDateTime(startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            var sqlEndTime = Convert.ToDateTime(endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            return _dal.AddReservation(new CreateReservationDto(roomId, userId, attendees, sqlStartTime, sqlEndTime));
        }
        public bool EditReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
            return _dal.UpdateReservation(reservation.ConvertToDto());
        }

        public bool ConfirmReservation(int id, string ip)
        {
            var reservation = _reservations.SingleOrDefault(res => res.ReservationId == id);
            var locations = LocationCollection.Instance.GetAllLocations();
            var match = locations.Any(res => res.IpAddress == ip);
            if (!match) return false;
            reservation?.ConfirmReservation(id);
            return true;
        }

        public bool DeleteReservation(int id)
        {
            return _dal.RemoveReservation(id);
        }
        
        public UserDto ConvertToDto()
        {
            return new UserDto(Id, Nickname, (int)Role);
        }
    }
}

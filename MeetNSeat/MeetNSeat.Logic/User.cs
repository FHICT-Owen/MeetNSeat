using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetNSeat.Logic
{
    public enum Role
    {
        User = 1,
        FacilityManager = 2,
        Admin = 3
    }
    
    public class User : IManageUser
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public Role Role { get; set; }
        private readonly List<Reservation> _reservations = new();
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
            var reservations = _dal.GetReservationByUser(id);

            for (int i = 0; i < reservations.Count; i++)
            {
                if (reservations[i].StartTime < DateTime.Now )
                {
                    reservations.RemoveAt(i);
                }
            }

            return reservations;
        }

        public bool AddReservation(string type,int roomId, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            if (startTime <= DateTime.Now || endTime <= DateTime.Now) return false;
            var sqlStartTime = Convert.ToDateTime(startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            var sqlEndTime = Convert.ToDateTime(endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            return _dal.AddReservation(new CreateReservationDto(roomId, userId, attendees, sqlStartTime, sqlEndTime));
        }

        public List<RoomDto> GetAvailableRooms(int locationId,string roomType, int attendees, DateTime startTime, DateTime endTime)
        {
            var availableRooms = new List<RoomDto>();
            if (endTime <= startTime || startTime <= DateTime.Now || endTime <= DateTime.Now) return availableRooms;
            var locationObject = new Location();
            var rooms = locationObject.GetAllRoomsWithType(roomType, locationId);
            var reservationObject = new Reservation();
            var reservations = reservationObject.GetAllReservations();
            foreach (var room in rooms)
            {
                if (attendees > room.Spots) continue;
                var interferingReservations = 
                    reservations.Where(reservation => 
                        reservation.RoomId == room.Id && !CheckForNoOverlap(reservation.StartTime, reservation.EndTime, startTime, endTime));
                
                if (interferingReservations.Any(reservation => reservation.RoomId == room.Id))
                {
                    room.IsAvailable = false;
                }
                else
                {
                    room.IsAvailable = true;
                    availableRooms.Add(room);
                }
            }
            return availableRooms;
        }

        public bool EditReservation(Reservation reservation)
        {
            var result = _reservations.SingleOrDefault(res => res.ReservationId == reservation.ReservationId);
            result?.EditReservation(reservation);
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
            return new(Id, Nickname, (int)Role);
        }

        public bool CheckForNoOverlap(DateTime dbStart, DateTime dbEnd, DateTime resStart, DateTime resEnd)
        {
            return resEnd <= dbStart || dbEnd <= resStart;
        }
    }
}

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
            return _dal.GetReservationByUser(id);
        }

        public bool AddReservation(string type,int roomId, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            if (startTime < DateTime.Now || endTime < DateTime.Now) return false;
            var sqlStartTime = Convert.ToDateTime(startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            var sqlEndTime = Convert.ToDateTime(endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            return _dal.AddReservation(new CreateReservationDto(roomId, userId, attendees, sqlStartTime, sqlEndTime));
        }
        public List<RoomDto> GetAvailableRooms(int locationId,string roomType, int attendees, DateTime startTime, DateTime endTime)
        {
            bool isAvailable = true;
            List<RoomDto> availableRooms = new List<RoomDto>();
            var locationObject = new Location();
            var rooms = locationObject.GetAllRoomsWithType(roomType, Convert.ToInt32(locationId));
            var reservationObject = new Reservation();
            var reservations = reservationObject.GetAllReservations();
            availableRooms.Clear();
            foreach (var room in rooms)
            {
                if (attendees <= room.Spots)
                {
                    foreach (var reservation in reservations)
                    {
                        // Check if the endtime in reservation is not in the past.
                        if (endTime < startTime)
                        { 
                            room.IsAvailable = false;
                        }

                            if (reservation.RoomId == room.Id && reservation.StartTime <= startTime && startTime <= reservation.EndTime ||
                                reservation.RoomId == room.Id && reservation.StartTime <= endTime && endTime <= reservation.EndTime ||
                                reservation.RoomId == room.Id && reservation.StartTime >= startTime && endTime >= reservation.EndTime)
                            {
                                room.IsAvailable = false;
                            }
                            else
                            {
                                room.IsAvailable = true;
                            }
                        

                    }
                    if (room.IsAvailable)
                    {
                        availableRooms.Add(room);
                    }
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
    }
}

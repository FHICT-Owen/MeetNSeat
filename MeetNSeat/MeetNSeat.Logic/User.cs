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
            Id = userDto.UserId;
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

        public List<ManageReservationDto> GetReservationByUser(string userId)
        {
            return _dal.GetReservationByUser(userId);
        }

        public bool AddReservation(string type, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            var isAvailable = true;
            // Retrieve rooms by type and location
            var roomObject = new Location();
            var rooms = roomObject.GetAvailableRooms(type, locationId);

            var roomId = 0;

            var reservationObject = new Reservation();
            var dbReservations = reservationObject.GetAllReservations();

            //TODO: Check if any room is available on given date
            // Loop trough reservations with given room id
            // Check if there is no reservation in given start and end

            foreach (var room in rooms)
            {
                foreach (var dbReservation in dbReservations)
                {
                    if (dbReservation.RoomId == room.Id &&
                        dbReservation.StartTime < startTime && startTime < dbReservation.EndTime ||
                        dbReservation.StartTime < endTime && endTime < dbReservation.EndTime ||
                        dbReservation.StartTime > startTime && endTime > dbReservation.EndTime)
                        
                        isAvailable = false;
                }
                roomId = room.Id;
            }
            if (!isAvailable) return false;
            
            var createReservationDto = new CreateReservationDto(roomId, userId, attendees, startTime, endTime);
            return _dal.AddReservation(createReservationDto);
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

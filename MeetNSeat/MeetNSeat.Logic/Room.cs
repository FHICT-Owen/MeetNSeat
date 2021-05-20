using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Room
    {
        private IRoomDal dal;

        public int Id { get; set; }
        public int FloorId { get; set; }
        public string Type { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }


        public Room(string type)
        {
            Type = type;
        }

        public Room(RoomDto roomDto) : this(roomDto.Type){}

        public Room()
        {
            dal = RoomFactory.CreateRoomDal();
        }

        public List<RoomDto> GetAvailableRooms(string type, int locationId)
        {
            return dal.GetAllRoomsByType(type, locationId);
        }

        public IReadOnlyCollection<RoomDto> GetRoomTypes()
        {
            return dal.GetAllRoomTypes();
        }
    }
}

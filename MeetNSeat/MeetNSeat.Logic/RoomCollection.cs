using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class RoomCollection : IManageRoom
    {
        private readonly List<Room> _rooms = new();

        private readonly IRoomDal _dal;
        public RoomCollection()
        {
            _dal = RoomFactory.CreateRoomDal();
        }
        public IReadOnlyCollection<Room> GetAllIssues()
        {
            throw new System.NotImplementedException();
        }

        public void AddRoom(int floorId, string name, string type, int spots, string facilities)
        {
            var room = new Room(floorId, name, spots, type, facilities);
            _rooms.Add(room);
            _dal.AddRoom(room.ConvertToDto());
        }
    }
}

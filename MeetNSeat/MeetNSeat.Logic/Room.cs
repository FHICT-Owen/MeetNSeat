using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
//using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MeetNSeat.Logic
{
    public class Room
    {
        public int Id { get; set; }
        private IRoomDal dal;

        public enum Type
        {
            Workplace,
            ConferenceRoom
        }

        public Room()
        {
            dal = RoomFactory.CreateRoomDal();
        }

        public void GetAvailableRoom()
        {
            var rooms = dal.GetAllRooms();

        }
    }
}

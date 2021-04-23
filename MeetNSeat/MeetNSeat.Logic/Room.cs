using System;
using System.Collections.Generic;
using System.Text;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

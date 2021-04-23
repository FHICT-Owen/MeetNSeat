using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.DbContext;

namespace MeetNSeat.Dal
{
    public class RoomDal : IRoomDal
    {
        private readonly DbContext.DbContext context; 
        public List<RoomDto> GetAllRooms()
        {
            var roomsList = context.Rooms.ToList();
            return roomsList;
        }
    }
}

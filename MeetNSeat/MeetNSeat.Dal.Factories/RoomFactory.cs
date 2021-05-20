﻿using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
    public class RoomFactory
    {
        public static IRoomDal CreateRoomDal()
        {
            return new RoomDal();
        }
    }
}

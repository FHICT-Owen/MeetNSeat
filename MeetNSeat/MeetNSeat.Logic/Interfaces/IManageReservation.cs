﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageReservation
    {
        public bool AddReservation(string type, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime);
    }
}

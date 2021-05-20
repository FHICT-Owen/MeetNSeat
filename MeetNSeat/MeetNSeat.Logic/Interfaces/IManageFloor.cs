﻿using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageFloor
    {
        IReadOnlyCollection<Floor> GetAllFloorsByLocation(int locationId);
        void AddFloor(Floor floor);
    }
}
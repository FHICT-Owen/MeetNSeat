﻿using System.Collections.Generic;

namespace MeetNSeat.Client.Models
{
    public class FloorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public List<RoomModel> Rooms { get; set; } = new();

        public FloorModel(int locationId, string name)
        {
            
            LocationId = locationId;    
            Name = name;
        }
    }
}

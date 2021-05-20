using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

//using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MeetNSeat.Logic
{
    public class Room
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }

        
    }
}

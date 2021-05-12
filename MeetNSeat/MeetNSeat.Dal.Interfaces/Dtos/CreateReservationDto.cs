using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class CreateReservationDto
    {
        public int RoomId { get; }
        public string UserId { get; }
        public int Attendees { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public CreateReservationDto(int roomId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            RoomId = roomId;
            UserId = userId;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}

using System;

namespace MeetNSeat.Client.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int Location { get; set; }
        public string UserId { get; set; }
        public int Attendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime IsConfirmed { get; set; }

        public ReservationModel(string userid, int location, int room, DateTime startDate, DateTime endDate)
        {
            UserId = userid;
            Location = location;
            RoomId = room;
            StartTime = startDate;
            EndTime = endDate;
        }
    }
}

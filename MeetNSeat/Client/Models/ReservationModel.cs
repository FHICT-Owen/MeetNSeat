using System;

namespace MeetNSeat.Client.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string LocationId { get; set; }
        public string UserId { get; set; }
        public int Attendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime IsConfirmed { get; set; }

        public ReservationModel(string userid, string locationId, string type, DateTime startDate, DateTime endDate)
        {
            UserId = userid;
            LocationId = locationId;
            Type = type;
            StartTime = startDate;
            EndTime = endDate;
        }
    }
}

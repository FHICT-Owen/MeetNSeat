using MeetNSeat.Logic;
using System;

namespace MeetNSeat.Server.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int FeedbackId { get; set; }
        public int RoomId { get; set; }
        public int LocationId { get; set; }
        public string UserId { get; set; }
        public int Attendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime IsConfirmed { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public Reservation ConvertToReservation()
        {
            return new Reservation(Id, RoomId,UserId,FeedbackId, Attendees, CreatedOn,StartTime ,EndTime, IsConfirmed );
        }
    }
}

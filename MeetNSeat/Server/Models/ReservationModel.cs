using MeetNSeat.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetNSeat.Server.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int FeedbackId { get; private set; }
        public int RoomId { get; set; }
        public int LocationId { get; set; }
        public string UserId { get; set; }
        public int Attendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime EndTime { get; set; }
        public DateTime IsConfirmed { get; set; }

        public Reservation ConvertToReservation()
        {
            return new Reservation(Id, RoomId,UserId,FeedbackId, Attendees, CreatedOn,StartTime ,EndTime, IsConfirmed );
        }
    }
}

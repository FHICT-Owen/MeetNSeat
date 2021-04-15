using System;
using System.Collections.Generic;
using System.Text;

namespace MeatNSeat.Logic
{
    public class Reservation
    {
        #region Properties
        public int Id { get; private set; }
        public int RoomId { get; private set; }
        public int ReservationCount { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime PlannedDate { get; private set; }
        public bool IsConfirmed { get; private set; }
        #endregion Properties
        
        // Optional
        public enum Facilities
        {
            Whiteboard,
            Digitalscreen
        }
    }
}

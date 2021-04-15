using System;
using System.Collections.Generic;
using System.Text;

namespace MeatNSeat.Logic
{
    public class Room
    {
        public int Id { get; set; }
        public enum Type
        {
            Workplace,
            ConferenceRoom
        }
    }
}

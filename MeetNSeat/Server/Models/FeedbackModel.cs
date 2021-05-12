using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetNSeat.Server.Models
{
    public class FeedbackModel
    {
        public int FeedbackId { get; set; }
        public string? Description { get; set; }
        public int? FeedbackState { get; set; }
    }
}

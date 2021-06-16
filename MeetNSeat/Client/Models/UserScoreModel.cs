namespace MeetNSeat.Client.Models
{
    public class UserScoreModel
    {
        public string UserId { get; set; }
        #nullable enable
        public string? NickName { get; set; }
        public int? Count { get; set; }
        public int? AvaragePerc { get; set; }
    }
}

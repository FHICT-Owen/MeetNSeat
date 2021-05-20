namespace MeetNSeat.Client.Models
{
    public class ConfirmationModel
    {
        public int ConfirmationId { get; set; }
        public string ConfirmationIp { get; set; }

        public ConfirmationModel(int confirmationId, string confirmationIp)
        {
            ConfirmationId = confirmationId;
            ConfirmationIp = confirmationIp;    
        }
    }
}

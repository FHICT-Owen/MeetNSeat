namespace MeetNSeat.Client.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string IpAddress { get; set; }

        public LocationModel(int id, string name, string city, string ipAddress)
        {
            Id = id;
            Name = name;
            City = city;
            IpAddress = ipAddress;
        }
        
    }
}

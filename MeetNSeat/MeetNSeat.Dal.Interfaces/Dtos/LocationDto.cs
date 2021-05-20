namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string IpAddress { get; set; }
        
        public LocationDto() { }
        public LocationDto(int id, string name, string city, string ipAddress)
        {
            Id = id;
            Name = name;
            City = city;
            IpAddress = ipAddress;
        }
    }
}
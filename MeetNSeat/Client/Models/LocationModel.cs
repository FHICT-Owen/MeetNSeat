﻿namespace MeetNSeat.Client.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string IpAddress { get; set; }

        public LocationModel(string name, string city, string ipAddress)
        {
            Name = name;
            City = city;
            IpAddress = ipAddress;
        }
        
    }
}
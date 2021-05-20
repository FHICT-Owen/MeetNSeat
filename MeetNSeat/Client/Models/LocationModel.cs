using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetNSeat.Client.Models
{
    public class LocationModel
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string IpAddress { get; set; }

        public LocationModel(int locationId, string name, string city, string ipAddress)
        {
            LocationId = locationId;
            Name = name;
            City = city;
            IpAddress = ipAddress;
        }
        
    }
}

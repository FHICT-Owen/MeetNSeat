using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeetNSeat.Client.Models
{
    public class IpAddress
    {
        [JsonPropertyName("ip")]
        public string IP { get; set; }

        [JsonPropertyName("geo-ip")]
        public string GeoIP { get; set; }

        [JsonPropertyName("API Help")]
        public string APIHelp { get; set; }
    }
}

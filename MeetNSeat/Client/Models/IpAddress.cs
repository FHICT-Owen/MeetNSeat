using System.Text.Json.Serialization;

namespace MeetNSeat.Client.Models
{
    public class IpAddress
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("geo-ip")]
        public string GeoIp { get; set; }

        [JsonPropertyName("API Help")]
        public string ApiHelp { get; set; }
    }
}

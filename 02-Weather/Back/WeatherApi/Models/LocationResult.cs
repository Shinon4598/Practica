namespace WeatherApi.Models
{
    public class LocationResult
    {
        public required string Name { get; set; }
        public required string Country { get; set; }
        public string? State { get; set; }
        public required double Lat { get; set; }
        public required double Lon { get; set; }
    }
}

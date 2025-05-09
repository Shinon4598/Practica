namespace WeatherApi.Models
{
    public class WeatherResult
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        required public string Main { get; set; }
        public double Feels_like { get; set; }
        public double Sensation { get; set; }
        public string? Description { get; set; } 
        public string? Icon { get; set; }
        public double Wind_speed { get; set; }
        public double Humidity { get; set; }
        public double Visibility { get; set; }
        public double Pressure { get; set; }

    }
}

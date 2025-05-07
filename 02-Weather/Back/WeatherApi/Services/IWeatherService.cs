using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface IWeatherService
    {
        public Task<IEnumerable<LocationResult>> GetLocationsAsync(string city);
        public Task<WeatherResult> GetWeatherAsync(double lat, double lon);

    }
}

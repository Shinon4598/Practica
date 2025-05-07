using System.Text.Json;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<IEnumerable<LocationResult>> GetLocationsAsync(string city)
        {
            var client = _httpClient.CreateClient();
            var apiKey = _configuration["OpenWeatherMap:ApiKey"];
            var url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=5&appid={apiKey}";
            var response = await client.GetFromJsonAsync<List<LocationResult>>(url);
            return response ?? Enumerable.Empty<LocationResult>();
        }

        public async Task<WeatherResult> GetWeatherAsync(double lat, double lon)
        {
            var client = _httpClient.CreateClient();
            var apiKey = _configuration["OpenWeatherMap:ApiKey"];
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric&lang=es";
            
            var response = await client.GetFromJsonAsync<JsonElement>(url);

            return new WeatherResult
            {
                City = response.GetProperty("name").GetString(),
                Temperature = response.GetProperty("main").GetProperty("temp").GetDouble(),
                Description = response.GetProperty("weather")[0].GetProperty("description").GetString()
            } ?? new WeatherResult();
        }
    }
}

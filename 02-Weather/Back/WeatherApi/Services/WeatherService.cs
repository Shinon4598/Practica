using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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
            var response = await client.GetFromJsonAsync<List<JsonElement>>(url);
            var locations = response?.Select(x => new LocationResult
            {
                Name = x.GetProperty("name").GetString(),
                Country = x.GetProperty("country").GetString(),
                State = x.TryGetProperty("state", out var state) ? state.GetString() : null,
                Lat = x.GetProperty("lat").GetDouble(),
                Lon = x.GetProperty("lon").GetDouble()
            }).ToList();
            return locations ?? Enumerable.Empty<LocationResult>();
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
                Description = response.GetProperty("weather")[0].GetProperty("description").GetString(),
                Icon = response.GetProperty("weather")[0].GetProperty("icon").GetString()
            } ?? new WeatherResult();
        }
    }
}

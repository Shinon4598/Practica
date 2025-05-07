using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
           _weatherService = weatherService;
        }
        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations(string city)
        {
            var cities = await _weatherService.GetLocationsAsync(city);
            return Ok(cities);
        }
        [HttpGet("Weather")]
        public async Task<IActionResult> GetWeather([FromQuery]double lat, [FromQuery]double lon)
        {
            var weather = await _weatherService.GetWeatherAsync(lat, lon);
            if (weather == null) return NotFound("No se encontró clima para esas coordenadas");
            return Ok(weather);
        }

    }
}

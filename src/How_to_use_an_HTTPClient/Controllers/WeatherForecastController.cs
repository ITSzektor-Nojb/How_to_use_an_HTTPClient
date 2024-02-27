using How_to_use_an_HTTPClient.Clients;
using How_to_use_an_HTTPClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace How_to_use_an_HTTPClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherClient _weatherClient;

        public WeatherForecastController(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        [HttpGet]
        public async Task<WeatherResponse?> Get(string city)
        {
            return await _weatherClient.GetCurrentWeatherForCity(city);
        }
    }
}

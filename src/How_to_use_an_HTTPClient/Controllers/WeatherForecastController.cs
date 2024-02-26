using How_to_use_an_HTTPClient.Clients;
using How_to_use_an_HTTPClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace How_to_use_an_HTTPClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }

        [HttpGet]
        public async Task<WeatherResponse?> Get(string city)
        {
            var client = new OpenWeatherClient();
            return await client.GetCurrentWeatherForCity(city);
        }
    }
}

using How_to_use_an_HTTPClient.Models;

namespace How_to_use_an_HTTPClient.Clients
{
    public class OpenWeatherClient : IWeatherClient
    {
        private const string OpenWeatherMapApiKey = "a96e82d421fbd096abf36e26d30944e5";

        private readonly IHttpClientFactory _httpClientFactory;

        public OpenWeatherClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherResponse?> GetCurrentWeatherForCity(string city)
        {
            var client = _httpClientFactory.CreateClient("weatherApi");

            return
                await client.GetFromJsonAsync<WeatherResponse?>(
                    $"weather?q={city}&appid={OpenWeatherMapApiKey}&units=metric");
        }
    }

    public interface IWeatherClient
    {
        Task<WeatherResponse?> GetCurrentWeatherForCity(string city);
    }
}

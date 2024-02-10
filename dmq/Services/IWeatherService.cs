using dmq.Configuations;
using Microsoft.Extensions.Options;

namespace dmq.Services
{
    public interface IWeatherService
    {
        Task<string> GetWeatherHereAsync();

        Task<string> GetWeatherByCityAsync(string city);
    }

    public class OpenWeatherMapService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AqicnOptions> _options;
        private readonly string _url = "https://api.waqi.info/";
        private readonly string _token = string.Empty;

        public OpenWeatherMapService(IHttpClientFactory httpClientFactory,
            IOptions<AqicnOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options;
            _token = options.Value.Token;
        }

        public async Task<string> GetWeatherByCityAsync(string city)
        {
            var client = _httpClientFactory.CreateClient();
            var endpoint = BuidEndpoint($"{_url}feed/{city}");
            var res = await client.GetStringAsync(endpoint);
            return res;
        }

        public async Task<string> GetWeatherHereAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var endpoint = BuidEndpoint($"{_url}feed/here");
            var res = await client.GetStringAsync(endpoint);
            return res;
        }

        private string BuidEndpoint(string uri)
        {
            return $"{uri}/?token={_token}";
        }
    }
}
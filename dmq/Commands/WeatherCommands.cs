using Cocona;
using dmq.Services;

namespace dmq.Commands
{
    public class WeatherCommands
    {
        private readonly IWeatherService _weatherService;

        public WeatherCommands(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        private async Task WeatherHere()
        {
            var weather = await _weatherService.GetWeatherHereAsync();
            Console.WriteLine(weather);
        }

        [Command("weather")]
        [OptionLikeCommand("here", new[] { 'h' }, typeof(WeatherCommands), nameof(WeatherHere))]
        public async Task WeatherByCity(string city)
        {
            var weather = await _weatherService.GetWeatherByCityAsync(city);
            Console.WriteLine(weather);
        }
    }
}
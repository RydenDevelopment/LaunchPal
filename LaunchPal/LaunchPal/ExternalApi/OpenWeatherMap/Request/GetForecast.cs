using System;
using System.Threading.Tasks;
using LaunchPal.ExternalApi.OpenWeatherMap.JsonObject;

namespace LaunchPal.ExternalApi.OpenWeatherMap.Request
{
    class GetForecast
    {
        // Read from the OPENWEATHERMAP_API_KEY environment variable so the key is never committed.
        private static string ApiKey =>
            Environment.GetEnvironmentVariable("OPENWEATHERMAP_API_KEY")
            ?? throw new InvalidOperationException("Environment variable OPENWEATHERMAP_API_KEY is not set.");

        internal static async Task<Forecast> GetForecastByCoordinates(string latitude, string longitude)
        {
            string apiUrl = $"forecast?lat={latitude}&lon={longitude}&units=metric&APPID={ApiKey}";
            var forecast = await HttpCaller.CallOpenWeatherMapApi<Forecast>(apiUrl);

            return forecast ?? new Forecast();
        }
    }
}

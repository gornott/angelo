using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FiveCast.Model;

namespace FiveCast.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient = new();
        private const string ApiKey = "38215da1a6fd47c08db203836251305";

        public async Task<ForecastData> GetForecastAsync(string city, string country, DateTime startDate, int numOfDays)
        {
            string query = $"{city},{country}";
            string url = $"http://api.worldweatheronline.com/premium/v1/weather.ashx" +
                         $"?q={query}" +
                         $"&format=json" +
                         $"&key={ApiKey}" +
                         $"&date={startDate:yyyy-MM-dd}" +
                         $"&num_of_days={numOfDays}";

            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return null;

                string json = await response.Content.ReadAsStringAsync();
                var wrapper = JsonConvert.DeserializeObject<ForecastDataWrapper>(json);
                return new ForecastData(wrapper.data);
            }
            catch
            {
                return null;
            }
        }

        private class ForecastDataWrapper
        {
            public ForecastData.Data data { get; set; }
        }
    }
}
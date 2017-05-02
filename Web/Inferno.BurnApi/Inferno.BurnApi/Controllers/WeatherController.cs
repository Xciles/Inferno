using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Inferno.BurnApi.ServiceModels;
using Inferno.BurnApi.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Inferno.BurnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Weather")]
    public class WeatherController : Controller
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

        private readonly string _openWeatherMapUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";


        [HttpGet("Raw/{latitude}&{longitude}")]
        public async Task<WeatherResult> GetWeather(float latitude, float longitude)
        {
            using (var client = new HttpClient())
            {
                var uri = String.Format(_openWeatherMapUri, latitude.ToString("G", new CultureInfo("en-US")), longitude.ToString("G", new CultureInfo("en-US")), _wheaterAppId);
                var httpResponseMessage = await client.GetAsync(uri);
                httpResponseMessage.EnsureSuccessStatusCode();

                var resultAsString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResult>(resultAsString, _jsonSerializerSettings);
            }
        }

        [HttpGet("Parsed/{latitude}&{longitude}")]
        public async Task<WeatherResponse> GetParsed(float latitude, float longitude)
        {
            var weather = await GetWeather(latitude, longitude);

            return new WeatherResponse()
            {
                WindDirection = WindDirection.WindDegreesToDirection(weather.Wind.Deg),
                WindDegree = weather.Wind.Deg,
                WindSpeed = weather.Wind.Speed
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Inferno.BurnApi.ServiceModels
{
    public class WeatherResult
    {
        [JsonProperty(PropertyName = "coord")]
        public Coord Coordinate { get; set; }

        [JsonProperty(PropertyName = "sys")]
        public Sys Sys { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty(PropertyName = "_base")]
        public string Base { get; set; }

        [JsonProperty(PropertyName = "main")]
        public Main Main { get; set; }

        [JsonProperty(PropertyName = "wind")]
        public Wind Wind { get; set; }

        [JsonProperty(PropertyName = "rain")]
        public Rain Rain { get; set; }

        [JsonProperty(PropertyName = "clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty(PropertyName = "dt")]
        public int Dt { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "cod")]
        public EWeatherCode WeatherCode { get; set; }
    }

    public class Coord
    {
        [JsonProperty(PropertyName = "lon")]
        public float Lon { get; set; }
        [JsonProperty(PropertyName = "lat")]
        public float Lat { get; set; }
    }

    public class Sys
    {
        [JsonProperty(PropertyName = "message")]
        public float Message { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "sunrise")]
        public float Sunrise { get; set; }
        [JsonProperty(PropertyName = "sunset")]
        public float Sunset { get; set; }
    }

    public class Main
    {
        [JsonProperty(PropertyName = "temp")]
        public float Temp { get; set; }
        [JsonProperty(PropertyName = "pressure")]
        public float Pressure { get; set; }
        [JsonProperty(PropertyName = "humidity")]
        public float Humidity { get; set; }
        [JsonProperty(PropertyName = "temp_min")]
        public float TempMin { get; set; }
        [JsonProperty(PropertyName = "temp_max")]
        public float TempMax { get; set; }
        [JsonProperty(PropertyName = "sea_level")]
        public float SeaLevel { get; set; }
        [JsonProperty(PropertyName = "grnd_level")]
        public float GrndLevel { get; set; }
    }

    public class Wind
    {
        [JsonProperty(PropertyName = "speed")]
        public float Speed { get; set; }
        [JsonProperty(PropertyName = "deg")]
        public float Deg { get; set; }
    }

    public class Rain
    {
        [JsonProperty(PropertyName = "_3h")]
        public float _3H { get; set; }
    }

    public class Clouds
    {
        [JsonProperty(PropertyName = "all")]
        public float All { get; set; }
    }

    public class Weather
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "main")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inferno.BurnApi.ServiceModels
{
    public class WeatherResponse
    {
        // wind
        // windrichting
        public float WindSpeed { get; set; }
        public float WindDegree { get; set; }
        public string WindDirection { get; set; }
    }
}

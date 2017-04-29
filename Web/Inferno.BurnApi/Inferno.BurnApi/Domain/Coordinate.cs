using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace Inferno.BurnApi.Domain
{
    public class Coordinate
    {
        public Coordinate()
        {
        }

        public Coordinate(ICoordinates coord)
        {
            Longitude = coord.Longitude;
            Latitude = coord.Latitude;
        }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}

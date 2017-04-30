using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Tweetinvi.Models;

namespace Inferno.BurnApi.Extensions
{
    public static class TwitterCoordinateExtensions
    {
        public static GeoCoordinate ToGeoCoordinate(this ICoordinates coord)
        {
            return new GeoCoordinate(coord.Latitude, coord.Longitude);
        }
    }
}

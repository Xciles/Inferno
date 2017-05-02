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


        const double TWOPI = 6.2831853071795865;
        const double RAD2DEG = 57.2957795130823209;
        public static double GetDegrees(this GeoCoordinate fromCoord, GeoCoordinate toCoord)
        {        
            if(fromCoord == toCoord)
            {
                return 0;
            }

            double theta = Math.Atan2(toCoord.Latitude - fromCoord.Latitude, fromCoord.Longitude - toCoord.Longitude);
            if (theta < 0.0)
                theta += TWOPI;
            return RAD2DEG * theta;
        }
    }
}

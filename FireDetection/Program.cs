using System;

namespace BurnBabyBurn
{
    public class Program
    {
        private const double WGS84a = 6378137.0;
        private const double WGS84b = 6356752.3;


        public static void Main(string[] args)
        {
            var point = new MapPoint();
            point.Latitude = 27.241733829962886;
            point.Longitude = 84.9503231048584;
            var box = GetBoundingBox(point,10);
            var boxAsString = $"{box.MinPoint.Latitude},{box.MinPoint.Longitude},{box.MaxPoint.Latitude},{box.MaxPoint.Longitude}";
            Console.WriteLine($"Coordinate: {point.Latitude},{point.Longitude}");
            Console.WriteLine($"Bounding box: {boxAsString}");;
            Console.WriteLine("");
            Console.WriteLine($"Photo: http://services.sentinel-hub.com/v1/wms/09d854b7-bcbf-74b0-7e1c-fd732f570a31?REQUEST=GetMap&FORMAT=image/jpg&LAYERS=TRUE_COLOR&WIDTH=1000&HEIGHT=750&srs=epsg:4326&BBOX={boxAsString}");
            Console.WriteLine($"FireIndex: http://services.sentinel-hub.com/v1/wms/09d854b7-bcbf-74b0-7e1c-fd732f570a31?REQUEST=GetMap&FORMAT=image/jpg&LAYERS=ACTIVEFIREINDEX&WIDTH=1000&HEIGHT=750&srs=epsg:4326&BBOX={boxAsString}");
            Console.ReadLine();
        }

        public class MapPoint
        {
            public double Longitude { get; set; }
            public double Latitude { get; set; }
        }

        public class BoundingBox
        {
            public MapPoint MinPoint { get; set; }
            public MapPoint MaxPoint { get; set; }
        }

        public static BoundingBox GetBoundingBox(MapPoint point, double halfSideInKm)
        {
            var lat = Deg2rad(point.Latitude);
            var lon = Deg2rad(point.Longitude);
            var halfSide = 1000 * halfSideInKm;

            var radius = WGS84EarthRadius(lat);
            var pradius = radius * Math.Cos(lat);

            var latMin = lat - halfSide / radius;
            var latMax = lat + halfSide / radius;
            var lonMin = lon - halfSide / pradius;
            var lonMax = lon + halfSide / pradius;

            return new BoundingBox
            {
                MinPoint = new MapPoint { Latitude = Rad2deg(latMin), Longitude = Rad2deg(lonMin) },
                MaxPoint = new MapPoint { Latitude = Rad2deg(latMax), Longitude = Rad2deg(lonMax) }
            };
        }

        private static double Deg2rad(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        private static double Rad2deg(double radians)
        {
            return 180.0 * radians / Math.PI;
        }

        private static double WGS84EarthRadius(double lat)
        {
            // http://en.wikipedia.org/wiki/Earth_radius
            var An = WGS84a * WGS84a * Math.Cos(lat);
            var Bn = WGS84b * WGS84b * Math.Sin(lat);
            var Ad = WGS84a * Math.Cos(lat);
            var Bd = WGS84b * Math.Sin(lat);
            return Math.Sqrt((An * An + Bn * Bn) / (Ad * Ad + Bd * Bd));
        }

    }
}

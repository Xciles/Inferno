using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Newtonsoft.Json;
using Tweetinvi.Models;

namespace Inferno.BurnApi.Domain
{
    public class Drone
    {
        public int Id { get; set; }

        [NotMapped]
        public GeoCoordinate BaseLocation
        {
            get
            {
                if (String.IsNullOrWhiteSpace(BaseLocationAsJson))
                    return null;

                return JsonConvert.DeserializeObject<GeoCoordinate>(BaseLocationAsJson);
            }
            set { BaseLocationAsJson = JsonConvert.SerializeObject(value); }
        }
        public string BaseLocationAsJson { get; set; }

        [NotMapped]
        public GeoCoordinate CurrentLocation
        {
            get
            {
                if (String.IsNullOrWhiteSpace(BaseLocationAsJson))
                    return null;

                return JsonConvert.DeserializeObject<GeoCoordinate>(BaseLocationAsJson);
            }
            set { CurrentLocationAsJson = JsonConvert.SerializeObject(value); }
        }
        public string CurrentLocationAsJson { get; set; }

        public int BatteryLevel { get; set; }
        public bool Available { get; set; }


        public int? ActiveDroneAssignmentId { get; set; }
        public DroneAssignment ActiveDroneAssignment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Inferno.BurnApi.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Tweetinvi.Models;

namespace Inferno.BurnApi.Domain
{
    public class FireReport
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public Coordinate Coordinates
        {
            get
            {
                if (String.IsNullOrWhiteSpace(CoordinateAsJson))
                    return null;

                return JsonConvert.DeserializeObject<Coordinate>(CoordinateAsJson);
            }
            set { CoordinateAsJson = JsonConvert.SerializeObject(value); }
        }
        public string CoordinateAsJson { get; set; }

        [NotMapped]
        public IList<Coordinate> BoundingBox
        {
            get
            {
                if (String.IsNullOrWhiteSpace(BoundingboxAsJson))
                    return null;

                return JsonConvert.DeserializeObject<IList<Coordinate>>(BoundingboxAsJson);
            }

            set { BoundingboxAsJson = JsonConvert.SerializeObject(value); }
        }

        public string BoundingboxAsJson { get; set; }

        public EFireSeverity FireSeverity { get; set; }
        public DateTime TimeStamp { get; set; }

        //public DroneAssignment DroneAssignment { get; set; }
        //public int? DroneAssignmentId { get; set; }

    }
}
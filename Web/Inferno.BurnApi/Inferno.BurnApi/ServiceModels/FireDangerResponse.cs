using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inferno.BurnApi.Business;
using Inferno.BurnApi.Domain.Enums;

namespace Inferno.BurnApi.ServiceModels
{
    public class FireDangerResponse
    {
        public bool IsSafe { get; set; }
        public double? ClosestFireInKm { get; set; }
        public double? HeadingDegrees { get; set; }
        public string HeadingString { get; set; }
        public Domain.FireReport FireReport { get; set; }
    }
}

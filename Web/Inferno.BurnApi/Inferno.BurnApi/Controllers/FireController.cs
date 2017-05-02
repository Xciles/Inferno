using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Inferno.BurnApi.Business.Interfaces;
using Inferno.BurnApi.Domain.Enums;
using Inferno.BurnApi.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inferno.BurnApi.Extensions;
using Inferno.BurnApi.Utils;

namespace Inferno.BurnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/FireDanger")]
    public class FireController : Controller
    {
        private readonly IFireReport _fireReport;

        public FireController(IFireReport fireReport)
        {
            _fireReport = fireReport;
        }

        [HttpPost]
        public async Task<FireDangerResponse> NearestFire([FromBody]GeoCoordinate geoCoordinate)
        {
            var closestReport = await _fireReport.GetClosestFireReport(geoCoordinate);

            if (closestReport == null)
            {
                return new FireDangerResponse()
                {
                    IsSafe = true
                };
            }
            var dis = closestReport.Coordinates.GetDistanceTo(geoCoordinate);
            return new FireDangerResponse()
            {
                IsSafe = IsSafe(geoCoordinate, closestReport),
                ClosestFireInKm = dis,
                HeadingDegrees = geoCoordinate.GetDegrees(closestReport.Coordinates),
                HeadingString = geoCoordinate.GetDegrees(closestReport.Coordinates).WindDegreesToDirectionString(),
                FireReport = closestReport              
            };
        }

        private bool IsSafe(GeoCoordinate geoCoordinate, Domain.FireReport closestReport)
        {
            var dis = closestReport.Coordinates.GetDistanceTo(geoCoordinate);

            if (dis < 50)
            {
                return false;
            }
            else if (dis < 150 && closestReport.FireSeverity <= EFireSeverity.LargerThan10LessThan100Meters)
            {
                return false;
            }
            else if (dis < 550 && closestReport.FireSeverity <= EFireSeverity.LargerThan100LessThan500Meters)
            {
                return false;
            }
            else if (dis < 1050 && closestReport.FireSeverity <= EFireSeverity.LargerThan500LessThan1000Meters)
            {
                return false;
            }
            else if (dis < 10000 && closestReport.FireSeverity <= EFireSeverity.LargerThan1000Meters)
            {
                return false;
            }
            return true;
        }
    }
}
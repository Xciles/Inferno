using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Inferno.BurnApi.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Inferno.BurnApi.Data;
using Inferno.BurnApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Inferno.BurnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/FireReport")]
    public class FireReportController : Controller
    {
        private readonly IFireReport _fireReport;

        public FireReportController(InfernoDbContext context, IFireReport fireReport)
        {
            _fireReport = fireReport;
        }

        [HttpPost]
        public async Task<IActionResult> Fire([FromBody]FireReport report)
        {
            if (report != null && report.Coordinates != null)
            {
                report.BoundingBox = new List<GeoCoordinate>()
                {
                    report.Coordinates,
                    report.Coordinates,
                    report.Coordinates,
                    report.Coordinates
                };
                await _fireReport.AddReport(report);
            }
            return Ok("Burn baby burn!");
        }

        [HttpGet]
        public async Task<IList<FireReport>> GetAll()
        {
            return await _fireReport.GetAllLastHour();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inferno.BurnApi.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Inferno.BurnApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace Inferno.BurnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/FireReport")]
    public class FireReportController : Controller
    {
        private readonly InfernoDbContext _context;
        private readonly IFireReport _fireReport;

        public FireReportController(InfernoDbContext context, IFireReport fireReport)
        {
            _context = context;
            _fireReport = fireReport;
        }

        [HttpPost]
        public async Task<IActionResult> Fire([FromBody]Domain.FireReport report)
        {
            if (report != null && report.Coordinates != null)
            {
                await _fireReport.AddReport(report);
            }
            return Ok("Burn baby burn!");
        }
    }
}
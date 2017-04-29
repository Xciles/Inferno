using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inferno.BurnApi.Business.Interfaces;
using Inferno.BurnApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Inferno.BurnApi.Business
{
    public class FireReport : IFireReport
    {
        private readonly InfernoDbContext _context;

        public FireReport(InfernoDbContext context)
        {
            _context = context;
        }

        public async Task AddReport(Domain.FireReport report)
        {
            await _context.Set<Domain.FireReport>().AddAsync(report);
        }

        public async Task<Domain.FireReport> GetLatestFireReport()
        {
            var report = await (from f in _context.Set<Domain.FireReport>()
                    .Include(x => x.DroneAssignment)
                orderby f.TimeStamp descending 
                select f).FirstOrDefaultAsync();

            return report;
        }

    }
}

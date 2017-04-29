using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inferno.BurnApi.Business.Interfaces
{
    public interface IFireReport
    {
        Task AddReport(Domain.FireReport report);
        Task<Domain.FireReport> GetLatestFireReport();
    }
}

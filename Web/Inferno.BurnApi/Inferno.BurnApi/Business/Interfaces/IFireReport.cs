using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;

namespace Inferno.BurnApi.Business.Interfaces
{
    public interface IFireReport
    {
        Task AddReport(Domain.FireReport report);
        Task<Domain.FireReport> GetLatestFireReport();
        Task<IList<Domain.FireReport>> GetAllLastHour();
        Task<Domain.FireReport> GetClosestFireReport(GeoCoordinate coord);
        Task ClearAll();
    }
}

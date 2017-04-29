using System;
using System.Threading.Tasks;
using Domain.Enums;

namespace Services.Interfaces
{
	public interface IAlertService
	{
		Task<bool> AlertForFire(double lat, double lng, EFireSeverity severity, string description);
	}
}

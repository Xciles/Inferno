using System;
using System.Threading.Tasks;
using Domain.Enums;
using Services.Interfaces;
using Domain;
namespace Services
{
	public class AlertService : IAlertService
	{
		public async Task<bool> AlertForFire(double lat, double lng, EFireSeverity severity, string description)
		{
			var report = new FireReport()
			{
				Description = description,
				FireSeverity = severity,
				TimeStamp = DateTime.Now,
				Coordinates = new Coordinate()
				{
					Latitude = lat,
					Longitude = lng
				}
			};

			await Task.Delay(1000).ConfigureAwait(false);
			return true;
		}
	}
}

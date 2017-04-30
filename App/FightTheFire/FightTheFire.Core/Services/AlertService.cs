using System;
using System.Threading.Tasks;
using Domain.Enums;
using Services.Interfaces;
using Domain;
using Xciles.Uncommon;
using Xciles.Uncommon.Net;

namespace Services
{
	public class AlertService : IAlertService
	{
		public async Task<bool> AlertForFire(double lat, double lng, EFireSeverity severity, string description)
		{
			try
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

				var result = await UncommonRequestHelper.ProcessPostRequestAsync<FireReport>("http://inferno-web.azurewebsites.net/api/firereport", report, new UncommonRequestOptions()
				{
					Authorized = true,
					Timeout = 12000
				}).ConfigureAwait(false);

				if (result.StatusCode == System.Net.HttpStatusCode.OK)
					return true;
				return false;
			}
			catch (Exception e)
			{

			}
			return false;
		}
	}
}
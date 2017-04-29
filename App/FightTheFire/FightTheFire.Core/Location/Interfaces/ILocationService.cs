using System;
using MvvmCross.Plugins.Location;

namespace FightTheFire.Core.Location.Interfaces
{
	public interface ILocationService
	{
		MvxGeoLocation LastLocation();
	}
}

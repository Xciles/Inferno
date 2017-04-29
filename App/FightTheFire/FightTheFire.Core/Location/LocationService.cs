using System;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using FightTheFire.Core.Location.Interfaces;
using FightTheFire.Core.Messages;

namespace FightTheFire.Core.Location
{
	public class LocationService : ILocationService
	{
		private readonly IMvxLocationWatcher _watcher;
		private readonly IMvxMessenger _messenger;

		public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
		{
			_watcher = watcher;
			_messenger = messenger;
			var options = new MvxLocationOptions()
			{
				Accuracy = MvxLocationAccuracy.Fine,
				MovementThresholdInM = 5,
				TrackingMode = MvxLocationTrackingMode.Foreground
			};
			_watcher.Start(options, OnLocation, OnError);
			OnLocation(_watcher.CurrentLocation);
		}

		public MvxGeoLocation LastLocation()
		{
			if (_watcher.Started)
			{
				return _watcher.CurrentLocation;
			}
			else
			{
				var options = new MvxLocationOptions()
				{
					Accuracy = MvxLocationAccuracy.Fine,
					MovementThresholdInM = 5,
					TrackingMode = MvxLocationTrackingMode.Foreground
				};
				_watcher.Start(options, OnLocation, OnError);
				return _watcher.CurrentLocation;
			}
		}

		private void OnLocation(MvxGeoLocation location)
		{
			var message = new LocationMessage(this, location.Coordinates.Latitude, location.Coordinates.Longitude);

			_messenger.Publish(message);
		}

		private void OnError(MvxLocationError error)
		{
			Mvx.Error("Seen location error {0}", error.Code);
		}
	}
}
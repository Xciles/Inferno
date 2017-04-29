using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using FightTheFire.Core.Location.Interfaces;
using FightTheFire.Core.Location;
using MvvmCross.Plugins.Messenger;
using FightTheFire.Core.Messages;
using MvvmCross.Plugins.Location;

namespace FightTheFire.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		private readonly MvxSubscriptionToken _token;

		public FirstViewModel(IMvxLocationWatcher watcher)
		{
			var messenger = Mvx.Resolve<IMvxMessenger>();
			_token = messenger.Subscribe<LocationMessage>(OnLocationMessage);

			Mvx.RegisterSingleton<ILocationService>(new LocationService(watcher, messenger));
		}

		private void OnLocationMessage(LocationMessage locationMessage)
		{
			Coords = locationMessage.Lat + ", " + locationMessage.Lng;
			Count++;
		}

		private string _coords = "Waiting for location...";
		public string Coords
		{
			get { return _coords; }
			set { SetProperty(ref _coords, value); }
		}

		private int _count = 0;
		public int Count
		{
			get { return _count; }
			set
			{
				SetProperty(ref _count, value);
			}
		}
	}
}
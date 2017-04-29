using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using FightTheFire.Core.Location.Interfaces;
using FightTheFire.Core.Location;
using MvvmCross.Plugins.Messenger;
using FightTheFire.Core.Messages;
using MvvmCross.Plugins.Location;
using Plugin.Compass;
using Utils;
using System.Windows.Input;
using Services.Interfaces;
using Domain.Enums;

namespace FightTheFire.Core.ViewModels
{
	public class ReportViewModel : MvxViewModel
	{
		private readonly MvxSubscriptionToken _token;

		public ReportViewModel(IMvxLocationWatcher watcher)
		{
			// Message subs.
			var messenger = Mvx.Resolve<IMvxMessenger>();
			_token = messenger.Subscribe<LocationMessage>(OnLocationMessage);

			// Location service.
			Mvx.RegisterSingleton<ILocationService>(new LocationService(watcher, messenger));

			// Compass.
			CrossCompass.Current.CompassChanged += (s, e) =>
			{
				Heading = e.Heading;
			};
			CrossCompass.Current.Start();
		}

		private void OnLocationMessage(LocationMessage locationMessage)
		{
			Lat = locationMessage.Lat;
			Lng = locationMessage.Lng;
		}

		private double _lat;
		public double Lat
		{
			get { return _lat; }
			set { SetProperty(ref _lat, value); }
		}

		private double _lng;
		public double Lng
		{
			get { return _lng; }
			set
			{
				SetProperty(ref _lng, value);
			}
		}

		private string _description;
		public string Description
		{
			get { return _description; }
			set
			{
				SetProperty(ref _description, value);

			}

		private double _heading;
		public double Heading
		{
			get { return _heading; }
			set
			{
				SetProperty(ref _heading, value);
				RaisePropertyChanged(() => HeadingAsCompass);
			}
		}

		public string HeadingAsCompass
		{
			get
			{
				return HeadingHelper.GetWinddirection(Heading);
			}
		}

		public ICommand ReportFireCommand
		{
			get
			{
				return new MvxCommand(async () =>
					{
						var result = await Mvx.Resolve<IAlertService>().AlertForFire(Lat, Lng, EFireSeverity.LargerThan100LessThan500Meters, Description);
					});
			}
		}
	}
}
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
using MvvmCross.Platform.Core;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace FightTheFire.Core.ViewModels
{
	public class ReportViewModel : MvxViewModel
	{
		private readonly MvxSubscriptionToken _token;
		private Utils.Timer _timer;

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

			_timer = new Utils.Timer(async (obj) =>
			{
				await CheckDanger().ConfigureAwait(false);
			}, null, 5000, 15000);
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
		}

		private int _distance;
		public int Distance
		{
			get { return _distance; }
			set
			{
				SetProperty(ref _distance, value);
				RaisePropertyChanged(() => DistanceAsKm);
			}
		}

		private int _severityBar;
		public int SeverityBar
		{
			get { return _severityBar; }
			set
			{
				SetProperty(ref _severityBar, value);
				RaisePropertyChanged(() => SeverityAsString);

			}
		}

		private EFireSeverity _severity;
		public EFireSeverity Severity
		{
			get { return _severity; }
			set
			{
				SetProperty(ref _severity, value);

			}
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

		public string DistanceAsKm
		{
			get
			{
				if (Distance < 20)
				{
					return "The floor is lava!"; ;
				}
				else if (Distance >= 20 && Distance < 60)
				{
					return "Between 10 and 500 meters away"; ;
				}
				else if (Distance >= 60 && Distance < 80)
				{
					return "Between 500 and 2000 meters away";
				}
				else if (Distance >= 80)
				{
					return "More than 2 kilometers away";
				}
				return "";
			}
		}

		public string SeverityAsString
		{
			get
			{
				if (SeverityBar < 20)
				{
					Severity = EFireSeverity.LessThan10Meters;
					return "Less than 10 meters across";
				}
				else if (SeverityBar >= 20 && SeverityBar < 40)
				{
					Severity = EFireSeverity.LargerThan10LessThan100Meters;
					return "Between 10 and 100 meters across";
				}
				else if (SeverityBar >= 40 && SeverityBar < 60)
				{
					Severity = EFireSeverity.LargerThan100LessThan500Meters;
					return "Between 100 and 500 meters across";
				}
				else if (SeverityBar >= 60 && SeverityBar < 80)
				{
					Severity = EFireSeverity.LargerThan500LessThan1000Meters;
					return "Between 500 and 1000 meters across";
				}
				else if (SeverityBar >= 80)
				{
					Severity = EFireSeverity.LargerThan1000Meters;
					return "OMG it's a d-d-d-d-d-d-d-firestorm!";
				}
				return "";

			}
		}

		private async Task CheckDanger()
		{
			var result = await Mvx.Resolve<IAlertService>().CheckForFire(Lat, Lng).ConfigureAwait(false);

			if (result != null && !result.IsSafe)
			{
				// Nie veilig ohhhh sheeeeeeiiiit...
				var message = new DangerMessage(this, result);
				Mvx.Resolve<IMvxMessenger>().Publish(message); ;
			}
		}

		public ICommand ReportFireCommand
		{
			get
			{
				return new MvxCommand(async () =>
					{
						Mvx.Resolve<IMvxMainThreadDispatcher>().RequestMainThreadAction(() =>
						{
							Mvx.Resolve<IUserDialogs>().ShowLoading();
						});

						var result = await Mvx.Resolve<IAlertService>().AlertForFire(Lat, Lng, Severity, Description).ConfigureAwait(false);

						Mvx.Resolve<IMvxMainThreadDispatcher>().RequestMainThreadAction(() =>
						{
							Mvx.Resolve<IUserDialogs>().HideLoading();
						});

						if (!result)
							Mvx.Resolve<IUserDialogs>().Alert("Fire Report NOT sent!");
						else
							Mvx.Resolve<IUserDialogs>().Alert("Fire Report sent! The fireguys are on their way, in the meantime, have a drone! Thx K Bye!");
					});
			}
		}
	}
}
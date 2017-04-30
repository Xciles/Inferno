using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using Acr.UserDialogs;
using FightTheFire.Core.Messages;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using Android.Content;

namespace FightTheFire.Droid.Views
{
	[Activity(Label = "Fire Alert!", ScreenOrientation = ScreenOrientation.Portrait)]
	public class ReportView : MvxActivity
	{
		private MvxSubscriptionToken _token;
		private bool _shownDangerNotify = false;
		private bool _isLive = false;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			UserDialogs.Init(this.Application);
			SetContentView(Resource.Layout.ReportView);

			var messenger = Mvx.Resolve<IMvxMessenger>();
			_token = messenger.Subscribe<DangerMessage>(OnDangerMessage);
		}

		protected override void OnResume()
		{
			base.OnResume();
			_isLive = true;
		}

		protected override void OnPause()
		{
			_isLive = false;
			base.OnPause();
		}

		private void OnDangerMessage(DangerMessage dangerMessage)
		{
			var danger = dangerMessage.DangerReport;
			if (!_shownDangerNotify && !danger.IsSafe)
			{
				if (!_isLive)
				{
					// Instantiate the builder and set notification elements
					Notification.Builder builder = new Notification.Builder(this)
						.SetContentTitle("Danger! Fire!")
						.SetContentText("Please get out of the area, fire in the " + danger.HeadingString + "!")
						.SetSmallIcon(Resource.Drawable.notification_template_icon_low_bg);

					// Build the notification:
					Notification notification = builder.Build();

					// Get the notification manager:
					NotificationManager notificationManager =
						GetSystemService(Context.NotificationService) as NotificationManager;

					// Publish the notification:
					const int notificationId = 0;
					notificationManager.Notify(notificationId, notification);
				}
				else
				{
					Mvx.Resolve<IUserDialogs>().Alert("Danger! Fire! Please get out of the area, fire in the " + danger.HeadingString + "!");
				}

				_shownDangerNotify = true;
			}
		}
	}
}
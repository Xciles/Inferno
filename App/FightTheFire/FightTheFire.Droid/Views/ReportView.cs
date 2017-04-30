using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using Acr.UserDialogs;

namespace FightTheFire.Droid.Views
{
	[Activity(Label = "Fire Alert!", ScreenOrientation = ScreenOrientation.Portrait)]
	public class ReportView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			UserDialogs.Init(this.Application);
			SetContentView(Resource.Layout.ReportView);
		}
	}
}
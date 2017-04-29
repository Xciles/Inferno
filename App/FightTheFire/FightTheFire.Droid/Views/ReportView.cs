using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;

namespace FightTheFire.Droid.Views
{
	[Activity(Label = "Report da fire", ScreenOrientation = ScreenOrientation.Portrait)]
	public class ReportView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ReportView);
		}
	}
}
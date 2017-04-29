using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace FightTheFire.Droid.Views
{
	[Activity(Label = "Report da fire")]
	public class ReportView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ReportView);
		}
	}
}
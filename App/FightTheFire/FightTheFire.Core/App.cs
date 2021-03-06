using Acr.UserDialogs;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace FightTheFire.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

			RegisterAppStart<ViewModels.ReportViewModel>();
		}
	}
}

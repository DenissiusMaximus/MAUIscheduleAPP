using Foundation;
using ScheduleApp.Services;
using UIKit;

[assembly: Microsoft.Maui.Controls.Dependency(typeof(ScheduleApp.iOS.AppRestartService_iOS))]
namespace ScheduleApp.iOS
{
    public class AppRestartService_iOS : IAppRestartService
    {
        public void RestartApp()
        {
            var storyboard = UIStoryboard.FromName("Main", null);
            var viewController = storyboard.InstantiateInitialViewController();
            var window = UIApplication.SharedApplication.KeyWindow;
            window.RootViewController = viewController;
        }
    }
}

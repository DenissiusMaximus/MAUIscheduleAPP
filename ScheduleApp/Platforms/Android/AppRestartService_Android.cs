using Android.App;
using Android.Content;
using ScheduleApp.Services;

[assembly: Microsoft.Maui.Controls.Dependency(typeof(ScheduleApp.Droid.AppRestartService_Android))]
namespace ScheduleApp.Droid
{
    public class AppRestartService_Android : IAppRestartService
    {
        public void RestartApp()
        {
            var context = Android.App.Application.Context;
            var packageManager = context.PackageManager;
            var intent = packageManager.GetLaunchIntentForPackage(context.PackageName);
            var componentName = intent.Component;
            var mainIntent = Intent.MakeRestartActivityTask(componentName);
            context.StartActivity(mainIntent);
            Java.Lang.JavaSystem.Exit(0);
        }
    }
}
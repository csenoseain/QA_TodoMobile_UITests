using System;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Todo.Mobile.UITests
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
            switch (platform)
            {
                case Platform.Android:
                    const string apkRelativePath = "../../app/Todo.Android.apk";
                    var apkPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, apkRelativePath);

                    return ConfigureApp
                        .Android
                        .ApkFile(apkPath)
                        .StartApp();

                case Platform.iOS:
                    return ConfigureApp
                        .iOS
                        .Debug()
                        .InstalledApp("com.your-company.Todo.iOS")
                        .StartApp();

                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }
	}
}

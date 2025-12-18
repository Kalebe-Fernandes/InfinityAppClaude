using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Apresentacao.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
        LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter([Intent.ActionView], Categories = [Intent.CategoryDefault, Intent.CategoryBrowsable], DataScheme = "infinityapp")]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}

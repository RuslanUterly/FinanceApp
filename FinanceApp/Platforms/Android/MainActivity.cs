using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using AndroidX.Navigation;
using Google.Android.Material.Navigation;
using Google.Android.Material.Tabs;
using Microsoft.Maui.Platform;

namespace FinanceApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        Window?.SetStatusBarColor(Color.FromRgba("FAFAFA").ToPlatform());
        Window?.SetNavigationBarColor(Color.FromRgba("F7F7F7").ToPlatform());
        Window?.SetBackgroundDrawable(new ColorDrawable(Color.FromRgba("#FAFAFA").ToPlatform()));

        
    }
}

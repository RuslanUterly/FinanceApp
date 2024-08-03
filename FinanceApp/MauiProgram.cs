using Data.Data;
using Data.Interfaces;
using Data.Repository;
using Microsoft.Extensions.Logging;
using Presentation.ViewModel.AddPages;
using Syncfusion.Maui.Core.Hosting;

namespace FinanceApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).ConfigureMauiHandlers(handler =>
                {
#if ANDROID
                    handler.AddHandler(typeof(Shell), typeof(Platforms.Android.CustomShell));
#endif
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}

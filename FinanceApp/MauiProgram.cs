﻿using Data.Data;
using Data.Interfaces;
using Data.Repository;
using Syncfusion.Maui.Core.Hosting;
using Microsoft.Extensions.Logging;
using Presentation.View.NavigationPages;
using Presentation.ViewModel.StatisticPages;
using UraniumUI;
using Microcharts.Maui;

namespace FinanceApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMicrocharts()
            .ConfigureSyncfusionCore()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).ConfigureMauiHandlers(handler =>
            {
#if ANDROID
                handler.AddHandler(typeof(Shell), typeof(Platforms.Android.CustomShell));
#endif
            })
            .Services.AddSingleton<DataFinanceContext>()
                     .AddSingleton<IFinanceRepository, FinanceRepository>()
                     .AddSingleton<IGroupRepository, GroupElementRepository>()
                     .AddSingleton<MainCostsView>()
                     .AddSingleton<MainProfitView>()
                     .AddSingleton<StatisticCostsViewModel>()
                     .AddSingleton<StatisticProfitViewModel>()
                     .AddSingleton<StatisticCostsView>()
                     .AddSingleton<StatisticProfitView>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}

using Data.Data;
using Data.Interfaces;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.ViewModel;

public static class Build
{
    public static IFinanceRepository GetFinanceService()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<DataFinanceContext>();
        services.AddTransient<IFinanceRepository, FinanceRepository>();

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider.GetRequiredService<IFinanceRepository>();
    }

    public static IChangeRepository GetChangeService()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<DataFinanceContext>();
        services.AddTransient<IFinanceRepository, FinanceRepository>();
        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider.GetRequiredService<IChangeRepository>();
    }

    //public static IFinanceRepository GetFinanceService(IServiceProvider serviceProvider)
    //{
    //    return serviceProvider.GetRequiredService<IFinanceRepository>();
    //}

    //public static IChangeRepository GetChangeService(IServiceProvider serviceProvider)
    //{
    //    return serviceProvider.GetRequiredService<IChangeRepository>();
    //}

    //public static IServiceProvider GetServiceProvider()
    //{
    //    IServiceCollection services = new ServiceCollection();
    //    services.AddTransient<DataFinanceContext>();
    //    services.AddTransient<IFinanceRepository, FinanceRepository>();
    //    //services.AddTransient<IChangeRepository, FinanceRepository>(); // использует тот же экземпляр

    //    return services.BuildServiceProvider();
    //}
}

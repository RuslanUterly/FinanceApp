using Data.Interfaces;
using Presentation.ViewModel.StatisticPages.ChartViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Model.Enum;
using System.Text;
using System.Threading.Tasks;
using Element = Model.DataModel.Element;
using Data.Repository;

namespace Presentation.ViewModel.StatisticPages;

public class StatisticCostsViewModel
{
    public StatisticCostsViewModel(IGroupRepository groupRepository)
    {
        OverallStatistics = new OverallStatisticsViewModel(Mode.Cost, groupRepository);
        AnnualStatistics = new AnnualStatisticsViewModel(Mode.Cost, groupRepository);
        MonthlyStatistics = new MonthlyStatisticsViewModel(Mode.Cost, groupRepository);
        WeeklyStatistics = new WeeklyStatisticsViewModel(Mode.Cost, groupRepository);
    }
    public OverallStatisticsViewModel OverallStatistics { get; }
    public AnnualStatisticsViewModel AnnualStatistics { get; }
    public MonthlyStatisticsViewModel MonthlyStatistics { get; }
    public WeeklyStatisticsViewModel WeeklyStatistics { get; }
}

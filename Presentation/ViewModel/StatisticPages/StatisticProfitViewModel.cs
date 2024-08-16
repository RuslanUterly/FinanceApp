using Data.Interfaces;
using Model.Enum;
using Presentation.ViewModel.StatisticPages.ChartViewModel;

namespace Presentation.ViewModel.StatisticPages;

public class StatisticProfitViewModel
{
    public StatisticProfitViewModel(IGroupRepository groupRepository)
    {
        OverallStatistics = new OverallStatisticsViewModel(Mode.Profit, groupRepository);
        AnnualStatistics = new AnnualStatisticsViewModel(Mode.Profit, groupRepository);
        MonthlyStatistics = new MonthlyStatisticsViewModel(Mode.Profit, groupRepository);
        WeeklyStatistics = new WeeklyStatisticsViewModel(Mode.Profit, groupRepository);
    }
    public OverallStatisticsViewModel OverallStatistics { get; }
    public AnnualStatisticsViewModel AnnualStatistics { get; }
    public MonthlyStatisticsViewModel MonthlyStatistics { get; }
    public WeeklyStatisticsViewModel WeeklyStatistics { get; }
}

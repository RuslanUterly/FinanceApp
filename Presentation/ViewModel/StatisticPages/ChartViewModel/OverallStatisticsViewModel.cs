using Data.Interfaces;
using Microcharts;
using Model.ChartModel;
using Model.Enum;
using Presentation.ViewModel.Builders.StatisticBuilder;
using Presentation.ViewModel.StatisticPages.ChartViewModel.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel.StatisticPages.ChartViewModel;

public class OverallStatisticsViewModel : INotifyPropertyChanged, IPeriodStatisticViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private Chart? chart;

    private StatisticModel model = new StatisticModel();
    private ChartBuilder printChart = new ChartBuilder();

    public OverallStatisticsViewModel(Mode mode, IGroupRepository groupRepository)
    {
        GroupRepository = groupRepository;
        Mode = mode;

        UpdateItems();
    }

    public ObservableCollection<Element> Elements
    { 
        get => model.Elements!;
        set
        { model.Elements = value; OnPropertyChanged(); }
    }

    public string ResultSum
    {
        get => model.ResultSum!;
        set
        { model.ResultSum = value; OnPropertyChanged(); }
    }

    public Chart ChartViewAll
    {
        get => chart!;
        set
        { chart = value; OnPropertyChanged(); }
    }

    public IGroupRepository GroupRepository { get; set ; }
    public Mode Mode { get; set; }

    private async void UpdateItems()
    {
        Elements = GroupRepository.GetByAllTime(Mode);
        ResultSum = $"Общая сумма: {await GroupRepository.GetSum(Elements)} руб.";
        ChartViewAll = printChart.Print(Elements);
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

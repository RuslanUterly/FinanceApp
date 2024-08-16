using Data.Interfaces;
using Microcharts;
using Model.ChartModel;
using Model.Enum;
using Presentation.ViewModel.Builders.PageBuilder;
using Presentation.ViewModel.Builders.PageBuilder.Interface;
using Presentation.ViewModel.Builders.StatisticBuilder;
using Presentation.ViewModel.StatisticPages.ChartViewModel.Interfaces;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel.StatisticPages.ChartViewModel;

public class AnnualStatisticsViewModel : INotifyPropertyChanged, IPeriodStatisticViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IPeriodChanger _statisticChanger;

    private Chart? chart;
    private List<DateTime>? dateTimes;
    private int dateOffset;

    private StatisticModel model = new StatisticModel();
    private ChartBuilder printChart = new ChartBuilder();

    public AnnualStatisticsViewModel(Mode mode, IGroupRepository groupRepository)
    {
        _statisticChanger = new PeriodChangeBuilder(mode, groupRepository, this);
        _statisticChanger.StatisticView += UpdateItems;

        OnForwardPeriod = new Command(async _ => await _statisticChanger.ForwardPeriod(ref dateOffset, 1));
        OnBackPeriod = new Command(async _ => await _statisticChanger.BackPeriod(ref dateOffset, 1));

        UpdateItems();
    }

    public ObservableCollection<Element> Elements
    {
        get => model.Elements!;
        set
        { model.Elements = value; OnPropertyChanged(); }
    }

    public string Period
    {
        get => model.DatePeriod!;
        set
        { model.DatePeriod = value; OnPropertyChanged(); }
    }

    public string ResultSum
    {
        get => model.ResultSum!;
        set
        { model.ResultSum = value; OnPropertyChanged(); }
    }

    public Chart ChartViewYear
    {
        get => chart!;
        set
            { chart = value; OnPropertyChanged(); }
    }

    public IGroupRepository GroupRepository { get; set; }
    public Mode Mode { get; set; }

    public ICommand OnForwardPeriod { get; }
    public ICommand OnBackPeriod { get; }

    private async void UpdateItems()
    {      
        (Elements, dateTimes) = await GroupRepository.GetByYear(Mode, dateOffset);
        Period = $"{dateTimes.First():yyyy} г.";
        ResultSum = $"Общая сумма: {await GroupRepository.GetSum(Elements)} руб.";
        ChartViewYear = printChart.Print(Elements);
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

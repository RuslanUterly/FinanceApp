using Data.Interfaces;
using Microcharts;
using SkiaSharp;
using Model.Enum;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Element = Model.DataModel.Element;
using System.Windows.Input;
using System;

namespace Presentation.ViewModel.StatisticPages.ChartViewModel;

public class WeeklyStatisticsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IGroupRepository _groupRepository;
    private readonly Mode _mode;

    private Chart chart;
    private string period;
    private string resultSum;
    private List<DateTime> dateTimes;
    private ObservableCollection<Element> elements;
    private int dateOffset;

    public WeeklyStatisticsViewModel(Mode mode, IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
        _mode = mode;

        OnForwardPeriod = new Command(async _ => await Forward());
        OnBackPeriod = new Command(async _ => await Back());

        UpdateItems();
    }

    public ObservableCollection<Element> Elements
    {
        get => elements;
        set
        { elements = value; OnPropertyChanged(); }
    }

    public string Period
    {
        get => period;
        set
        { period = value; OnPropertyChanged(); }
    }

    public string ResultSum
    {
        get => resultSum;
        set
        { resultSum = value; OnPropertyChanged(); }
    }
    public Chart ChartViewYear
    {
        get => chart;
        set
        { chart = value; OnPropertyChanged(); }
    }

    public ICommand OnForwardPeriod { get; }
    public ICommand OnBackPeriod { get; }

    private List<ChartEntry> SetEntries()
    {
        List<ChartEntry> entries = [];
        var items = Elements;

        foreach (var item in items)
        {
            entries.Add(new ChartEntry(Convert.ToInt32(item.Sum))
            {
                Label = item.Categoria!.Name,
                ValueLabel = item.Sum.ToString(),
                Color = SKColor.Parse(item.Categoria.Color),
            });
        }

        return entries;
    }

    public void Print()
    {
        List<ChartEntry> entries = SetEntries();

        ChartViewYear = new DonutChart()
        {
            Entries = entries,
            LabelTextSize = 35,
            BackgroundColor = SKColor.Parse("#FAFAFA"),
        };
        OnPropertyChanged();

        return;
    }

    private async Task Forward()
    {
        if (dateOffset == 0)
            return;

        dateOffset += 7;
        await UpdateItems();
    }

    private async Task Back()
    {
        dateOffset -= 7;

        await UpdateItems();
    }


    private async Task UpdateItems()
    {
        (Elements, dateTimes) = await _groupRepository.GetByWeek(_mode, default, dateOffset);
        Period = $"{dateTimes.First().ToString("dd.MM")} - {dateTimes.Last().ToString("dd.MM")}";
        ResultSum = $"Общая сумма: {await _groupRepository.GetSum(Elements)} руб.";
        Print();
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
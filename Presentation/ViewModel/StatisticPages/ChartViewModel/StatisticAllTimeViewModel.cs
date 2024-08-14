﻿using Data.Interfaces;
using Microcharts;
using Model.Enum;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel.StatisticPages.ChartViewModel;

public class StatisticAllTimeViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IGroupRepository _groupRepository;

    private Chart chart;
    private string period;
    private ObservableCollection<Element> elements;

    public StatisticAllTimeViewModel(Mode mode, IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;

        Elements = _groupRepository.GetByAllTime(mode);

        Print();
    }

    public ObservableCollection<Element> Elements
    { 
        get => elements;
        set
        {
            elements = value;
            OnPropertyChanged();
}
    }
    public string Period 
    { 
        get => period = "Весь период";
        set
        {
            period = value;
            OnPropertyChanged();
        }
    }
    public Chart ChartViewAll
    {
        get => chart;
        set
        {
            chart = value;
            OnPropertyChanged();
        }
    }

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

        ChartViewAll = new DonutChart()
        {
            Entries = entries,
            LabelTextSize = 35,
            BackgroundColor = SKColor.Parse("#FAFAFA"),
        };
        OnPropertyChanged();

        return;
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

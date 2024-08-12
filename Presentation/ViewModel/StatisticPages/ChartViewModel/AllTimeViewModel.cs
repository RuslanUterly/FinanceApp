using Data.Interfaces;
using Microcharts;
using Model.Enum;
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

class AllTimeViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private Chart chart;
    private readonly IFinanceRepository _financeRepository;

    public AllTimeViewModel(IFinanceRepository financeRepository)
    {
        _financeRepository = financeRepository;
    }

    public ObservableCollection<Element> Elements => GetElementsForPeriod(0);
    public Chart ChartViewAll
    {
        get => chart;
        set
        {
            chart = value;
            OnPropertyChanged(nameof(ChartViewAll));
        }
    } 

    private ObservableCollection<Element> GetElementsForPeriod(int period)
    {
        return null;   
    }

    private void GetFinanceList()
    {

    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

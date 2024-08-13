using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel.StatisticPages;

interface IStatisticViewModel
{
    ObservableCollection<Element> Elements { get; set; }
}

public class StatisticCostsViewModel : INotifyPropertyChanged, IStatisticViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private ObservableCollection<Element>? elements;

    public StatisticCostsViewModel()
    {
        
    }

    public ObservableCollection<Element> Elements
    {
        get => elements!;
        set
        {
            elements = value;
            OnPropertyChanged();
        }
    }
    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

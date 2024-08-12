using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel.StatisticPages;

public class StatisticCostsViewModel : INotifyPropertyChanged
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

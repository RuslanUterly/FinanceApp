using Model.DataModel;
using Model.IconModel;
using Presentation.Model.IconModel;
using Presentation.ViewModel.Builders.IconBuilder;
using Presentation.ViewModel.Builders.IconBuilder.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel.AddPages;

class AddProfitViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly Icon _icon;
    private readonly IColorUpdater _colorUpdater;
    private Categoria? previousSelectedItem;

    public AddProfitViewModel()
    {
        _icon = new Icon();
        _colorUpdater = new ColorUpdater();
        SelectionChangedCommand = new Command(OnSelectionChanged);
    }

    public ObservableCollection<Categoria> IconProfit
    {
        get => _icon.IconProfit;
        set
        {
            _icon.IconProfit = value;
            OnPropertyChanged();
        }
    }
    public ICommand SelectionChangedCommand { get; }

    private void OnSelectionChanged(object? sender)
    {
        if (sender is Categoria selectedItem)
        {
            _colorUpdater.UpdateColor(IconProfit, selectedItem);
            _colorUpdater.UpdateColor(IconProfit, previousSelectedItem);
            previousSelectedItem = selectedItem;

            OnPropertyChanged();
        }
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}

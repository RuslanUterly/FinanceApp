using Data.Interfaces;
using Model.DataModel;
using Model.Enum;
using Presentation.ViewModel.Builders.FinanceBuilder;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;
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
    //public event Action CostAdded;

    //private readonly IFinanceBuilder _financeBuilder;
    //private readonly IIconBuilder _iconBuilder;

    //public AddProfitViewModel(DateTime date, IFinanceRepository financeRepository)
    //{
    //    _financeBuilder = new FinanceBuilder(date, financeRepository);
    //    _iconBuilder = new IconBuilder();

    //    SelectionChangedCommand = new Command(OnSelectionChanged);
    //    CostCreateCommand = new Command<string>(OnCostCreate);
    //    ClosePageCommand = new Command(OnClosePage);
    //}

    //public ObservableCollection<Categoria> IconProfits
    //{
    //    get => _iconBuilder.Icon.IconProfit;
    //    set
    //    {
    //        _iconBuilder.Icon.IconProfit = value;
    //        OnPropertyChanged();
    //    }
    //}
    //public ICommand SelectionChangedCommand { get; }
    //public ICommand CostCreateCommand { get; }
    //public ICommand ClosePageCommand { get; }

    //private async void OnSelectionChanged(object? sender)
    //{
    //    if (sender is Categoria selectedItem)
    //    {
    //        await _iconBuilder.ChangeAsync(selectedItem, IconProfits);
    //    }
    //}

    //private async void OnCostCreate(string sum)
    //{
    //    await _financeBuilder.CreateAsync(Mode.profit, sum, _iconBuilder.SelectedItem);

    //    CostAdded?.Invoke();
    //    OnClosePage();
    //}

    //private async void OnClosePage() => await Application.Current!.MainPage!.Navigation.PopModalAsync();

    //public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

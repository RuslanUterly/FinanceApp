using Data.Interfaces;
using Model.DataModel;
using Model.Enum;
using FinanceApp.ViewModel.Builders.FinanceBuilder;
using FinanceApp.ViewModel.Builders.FinanceBuilder.Interfaces;
using FinanceApp.ViewModel.Builders.IconBuilder;
using FinanceApp.ViewModel.Builders.IconBuilder.Interfaces;
using FinanceApp.ViewModel.Builders.PageBuilder;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FinanceApp.ViewModel.AddPages;

public class AddProfitViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event Action? ProfitAdded;

    private readonly ICreateFinanceBuilder _financeBuilder;
    private readonly IIconBuilder _iconBuilder;

    public AddProfitViewModel(DateTime date, IFinanceRepository financeRepository)
    {
        _financeBuilder = new CreateFinanceBuilder(date, financeRepository);
        _iconBuilder = new IconBuilder();

        SelectionChangedCommand = new Command(async sender => await _iconBuilder.ChangeAsync(sender, IconProfit));
        ProfitCreateCommand = new Command<string>(async sum => await _financeBuilder.CreateAsync(Mode.Profit, sum, _iconBuilder.SelectedItem, ProfitAdded!));
        ClosePageCommand = new Command(ViewBuilder.OnClosePage);
    }

    public ObservableCollection<Categoria> IconProfit
    {
        get => _iconBuilder.Icon.IconProfit;
        set
        {
            _iconBuilder.Icon.IconCosts = value;
            OnPropertyChanged();
        }
    }
    public ICommand SelectionChangedCommand { get; }
    public ICommand ProfitCreateCommand { get; }
    public ICommand ClosePageCommand { get; }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

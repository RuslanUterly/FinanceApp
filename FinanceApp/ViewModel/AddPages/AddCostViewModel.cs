using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model.DataModel;
using Data.Interfaces;
using Model.Enum;
using FinanceApp.ViewModel.Builders.IconBuilder.Interfaces;
using FinanceApp.ViewModel.Builders.IconBuilder;
using FinanceApp.ViewModel.Builders.FinanceBuilder;
using FinanceApp.ViewModel.Builders.FinanceBuilder.Interfaces;
using FinanceApp.ViewModel.Builders.PageBuilder;

namespace FinanceApp.ViewModel.AddPages;

public class AddCostViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event Action? CostAdded; 

    private readonly ICreateFinanceBuilder _financeBuilder;
    private readonly IIconBuilder _iconBuilder;

    public AddCostViewModel(DateTime date, IFinanceRepository financeRepository)
    {
        _financeBuilder = new CreateFinanceBuilder(date, financeRepository);
        _iconBuilder = new IconBuilder();

        SelectionChangedCommand = new Command(async sender => await _iconBuilder.ChangeAsync(sender, IconCosts));
        CostCreateCommand = new Command<string>(async sum => await _financeBuilder.CreateAsync(Mode.Cost, sum, _iconBuilder.SelectedItem, CostAdded!));
        ClosePageCommand = new Command(ViewBuilder.OnClosePage);
    }

    public ObservableCollection<Categoria> IconCosts
    {
        get => _iconBuilder.Icon.IconCosts;
        set
        {
            _iconBuilder.Icon.IconCosts = value;
            OnPropertyChanged();
        }
    }
    public ICommand SelectionChangedCommand { get; }
    public ICommand CostCreateCommand { get; }
    public ICommand ClosePageCommand { get; }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
using Data.Interfaces;
using Model.DataModel;
using Model.Enum;
using Presentation.ViewModel.Builders.FinanceBuilder;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;
using Presentation.ViewModel.Builders.IconBuilder;
using Presentation.ViewModel.Builders.IconBuilder.Interfaces;
using Presentation.ViewModel.Builders.PageBuilder;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel.AddPages;

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
        get => _iconBuilder.Model.IconProfit;
        set
        {
            _iconBuilder.Model.IconCosts = value;
            OnPropertyChanged();
        }
    }
    public ICommand SelectionChangedCommand { get; }
    public ICommand ProfitCreateCommand { get; }
    public ICommand ClosePageCommand { get; }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

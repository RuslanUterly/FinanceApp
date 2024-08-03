using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model.IconModel;
using Model.DataModel;
using Data.Interfaces;
using Model.Enum;
using Presentation.ViewModel.Builders.IconBuilder.Interfaces;
using Presentation.ViewModel.Builders.IconBuilder;
using Presentation.ViewModel.Builders.FinanceBuilder;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;

namespace Presentation.ViewModel.AddPages;

public class AddCostViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event Action CostAdded; 

    //private readonly Icon _icon;
    //private readonly IColorUpdater _colorUpdater; 
    //private readonly DateTime _date;
    //private readonly IFinanceRepository _financeRepository;
    private readonly IFinanceBuilder _financeBuilder;
    private readonly IIconBuilder _iconBuilder;

    //private Categoria? previousSelectedItem;
    //private Categoria? selectedItem;

    public AddCostViewModel(DateTime date, IFinanceRepository financeRepository)
    {
        //_icon = new Icon();
        //_colorUpdater = new ColorUpdater();
        //_date = date;
        //_financeRepository = financeRepository;
        _financeBuilder = new FinanceBuilder(date, financeRepository);
        _iconBuilder = new IconBuilder();

        SelectionChangedCommand = new Command(OnSelectionChanged);
        CostCreateCommand = new Command<string>(OnCostCreate);
        ClosePageCommand = new Command(OnClosePage);
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

    private async void OnSelectionChanged(object? sender)
    {
        if (sender is Categoria selectedItem)
        {
            //this.selectedItem = new Categoria(selectedItem.Name, selectedItem.Icon, selectedItem.Color);

            //await _colorUpdater.UpdateColor(IconCosts, selectedItem);
            //await _colorUpdater.UpdateColor(IconCosts, previousSelectedItem!);

            //previousSelectedItem = selectedItem;

            await _iconBuilder.ChangeAsync(selectedItem, IconCosts);
        }
    }

    private async void OnCostCreate(string sum)
    {
        //if (sum == null && selectedItem == null)
        //    return;

        //await _financeRepository.Create(Mode.cost, Convert.ToDecimal(sum), selectedItem!, _date);
        await _financeBuilder.CreateAsync(Mode.cost, sum, _iconBuilder.SelectedItem);

        CostAdded?.Invoke();
        OnClosePage();
    }

    private async void OnClosePage() => await Application.Current!.MainPage!.Navigation.PopModalAsync();

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
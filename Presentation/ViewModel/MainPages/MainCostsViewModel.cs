using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Data.Interfaces;
using Model.Enum;
using Presentation.View.AddPages;
using Presentation.ViewModel.AddPages;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel;

public class MainCostsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IFinanceRepository _financeRepository;
    //private readonly IChangeRepository _changeRepository;
    private ObservableCollection<Element>? elements;
    private string elementsSum;
    private DateTime _date;

    public MainCostsViewModel()
    {
        //var serviceProvider = Build.GetServiceProvider();
        //_changeRepository = Build.GetChangeService(serviceProvider);
        //_changeRepository.ChangeElement += UpdateElements;

        _financeRepository = Build.GetFinanceService();

        DateChangedCommand = new Command<DateTime>(OnDateChanged);
        OpenPageCommand = new Command(OnOpenPage);
        DeleteCostCommand = new Command<Element>(OnDeleteCost);
    }

    public MainCostsViewModel(DateTime date) : this()
    {
        _date = date;
        UpdateElements();
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

    public string ElementsSum
    {
        get => elementsSum;
        set
        {
            elementsSum = value; 
            OnPropertyChanged(); 
        }
    }

    public ICommand OpenPageCommand { get; }
    public ICommand DateChangedCommand { get; }
    public ICommand DeleteCostCommand { get; }

    private async void OnOpenPage()
    {
        var addCostViewModel = new AddCostViewModel(_date, _financeRepository);
        // Подписка на событие
        addCostViewModel.CostAdded += UpdateElements;

        await Application.Current.MainPage.Navigation.PushModalAsync(new AddCostView(addCostViewModel));
    }

    private async void OnDateChanged(DateTime newDate)
    {
        _date = newDate;
        UpdateElements();
    }

    private async void OnDeleteCost(Element? element)
    {
        _financeRepository.Delete(_date, element);
        UpdateElements();
    }
    private async void UpdateElements()
    {
        Elements = await _financeRepository.GetAll(_date, Mode.cost);
        ElementsSum = $"{await _financeRepository.GetSum(_date, Mode.cost)} руб.";
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

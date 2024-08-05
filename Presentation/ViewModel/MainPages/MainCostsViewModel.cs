using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Data.Interfaces;
using Model.Enum;
using Presentation.View.AddPages;
using Presentation.ViewModel.AddPages;
using Presentation.ViewModel.Builders.FinanceBuilder;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel;

public interface IFinanceViewModel
{
    public DateTime Date { get; set; }
    public IFinanceRepository FinanceRepository { get; set; }
}

public class MainCostsViewModel : INotifyPropertyChanged, IFinanceViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly DeleteFinanceBuilder _deleteFinance;
    private readonly DateChangeBuilder _dateChange;
    private readonly OpenPageBuilder _openPage;

    //private readonly IFinanceRepository _financeRepository;
    private ObservableCollection<Element>? elements;
    private string? elementsSum;
    //public DateTime _date;

    public MainCostsViewModel(DateTime date, IFinanceRepository financeRepository)
    {
        //_financeRepository = financeRepository;
        //_date = date;
        //DateChangedCommand = new Command<DateTime>(OnDateChanged);
        //OpenPageCommand = new Command(OnOpenPage);
        //DeleteCostCommand = new Command<Element>(OnDeleteCost);

        _deleteFinance = new DeleteFinanceBuilder(date, financeRepository, this);
        _dateChange = new DateChangeBuilder(date, financeRepository, this);
        _openPage = new OpenPageBuilder(date, financeRepository, this);

        _deleteFinance.UpdateElements += UpdateElements;
        _dateChange.UpdateElements += UpdateElements;

        DateChangedCommand = new Command<DateTime>(async date => await _dateChange.DateChangeAsync(date));
        OpenPageCommand = new Command(async _ => await _openPage.OpenPageAsync(UpdateElements));
        DeleteCostCommand = new Command<Element>(async element => await _deleteFinance.DeleteAsync(element));

        UpdateElements();
    }

    public DateTime Date { get; set; }
    public IFinanceRepository FinanceRepository { get; set; }

    public ObservableCollection<Element> Elements
    {
        get => elements!;
        set
        {
            elements = value;
            OnPropertyChanged();
        }
    }

    public string ElementsSum
    {
        get => elementsSum!;
        set
        {
            elementsSum = value; 
            OnPropertyChanged(); 
        }
    }

    public ICommand OpenPageCommand { get; }
    public ICommand DateChangedCommand { get; }
    public ICommand DeleteCostCommand { get; }

    //private async void OnOpenPage()
    //{
    //    var addCostViewModel = new AddCostViewModel(_date, _financeRepository);
    //    // Подписка на событие
    //    addCostViewModel.CostAdded += UpdateElements;

    //    await Application.Current!.MainPage!.Navigation.PushModalAsync(new AddCostView(addCostViewModel));
    //}

    //private void OnDateChanged(DateTime newDate)
    //{
    //    _date = newDate;
    //    UpdateElements();
    //}

    //private async void OnDeleteCost(Element? element)
    //{
    //    await _financeRepository.Delete(_date, element!);
    //    UpdateElements();
    //}
    private async void UpdateElements()
    {
        //Elements = await _financeRepository.GetAll(_date, Mode.cost);
        //ElementsSum = $"{await _financeRepository.GetSum(_date, Mode.cost)} руб.";

        Elements = await FinanceRepository.GetAll(Date, Mode.cost);
        ElementsSum = $"{await FinanceRepository.GetSum(Date, Mode.cost)} руб.";
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

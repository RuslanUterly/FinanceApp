using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Data.Interfaces;
using Model.Enum;
using Presentation.ViewModel.Builders.FinanceBuilder;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;
using Presentation.ViewModel.Builders.PageBuilder.Interface;
using Presentation.ViewModel.MainPages.Intrerfaces;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel;

public class MainCostsViewModel : INotifyPropertyChanged, IFinanceViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly IDeleteFinanceBuilder _deleteFinance;
    private readonly IDateChangeBuilder _dateChange;
    private readonly IOpenPageBuilder _openPage;

    private ObservableCollection<Element>? elements;
    private string? elementsSum;

    public MainCostsViewModel(DateTime date, IFinanceRepository financeRepository)
    {
        _deleteFinance = new DeleteFinanceBuilder(date, financeRepository, this);
        _dateChange = new DateChangeBuilder(date, financeRepository, this);
        _openPage = new OpenPageBuilder(date, financeRepository, this);

        _deleteFinance.UpdateElements += UpdateElements;
        _dateChange.UpdateElements += UpdateElements;

        DateChangedCommand = new Command<DateTime>(async date => await _dateChange.DateChangeAsync(date));
        OpenPageCommand = new Command(async _ => await _openPage.OpenCostPageAsync(UpdateElements));
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

    private async void UpdateElements()
    {
        Elements = await FinanceRepository.GetAll(Date, Mode.cost);
        ElementsSum = $"{await FinanceRepository.GetSum(Date, Mode.cost)} руб.";
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

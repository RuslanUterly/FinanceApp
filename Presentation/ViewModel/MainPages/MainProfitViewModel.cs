using Presentation.ViewModel.MainPages.Intrerfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model.Enum;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Data.Interfaces;
using Element = Model.DataModel.Element;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;
using Presentation.ViewModel.Builders.PageBuilder.Interface;
using Presentation.ViewModel.Builders.FinanceBuilder;

namespace Presentation.ViewModel;

public class MainProfitViewModel : INotifyPropertyChanged, IFinanceViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly IDeleteFinanceBuilder _deleteFinance;
    private readonly IDateChangeBuilder _dateChange;
    private readonly IOpenPageBuilder _openPage;

    private ObservableCollection<Element>? elements;
    private string? elementsSum;

    public MainProfitViewModel(DateTime date, IFinanceRepository financeRepository)
    {
        _deleteFinance = new DeleteFinanceBuilder(date, financeRepository, this);
        _dateChange = new DateChangeBuilder(date, financeRepository, this);
        _openPage = new OpenPageBuilder(date, financeRepository, this);

        _deleteFinance.UpdateElements += UpdateElements;
        _dateChange.UpdateElements += UpdateElements;

        DateChangedCommand = new Command<DateTime>(async date => await _dateChange.DateChangeAsync(date));
        OpenPageCommand = new Command(async _ => await _openPage.OpenProfitPageAsync(UpdateElements));
        DeleteProfitCommand = new Command<Element>(async element => await _deleteFinance.DeleteAsync(element));

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
    public ICommand DeleteProfitCommand { get; }

    private async void UpdateElements()
    {
        Elements = await FinanceRepository.GetAll(Date, Mode.Profit);
        ElementsSum = $"{await FinanceRepository.GetSum(Date, Mode.Profit)} руб.";
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}

using Data.Interfaces;
using Model.DataModel;
using Model.Enum;
using FinanceApp.View.AddPages;
using FinanceApp.ViewModel.AddPages;
using FinanceApp.ViewModel.Builders.FinanceBuilder.Interfaces;
using FinanceApp.ViewModel.Builders.PageBuilder;
using FinanceApp.ViewModel.Builders.PageBuilder.Interface;
using FinanceApp.ViewModel.MainPages.Intrerfaces;
using Element = Model.DataModel.Element;

namespace FinanceApp.ViewModel.Builders.FinanceBuilder;

public class CreateFinanceBuilder(DateTime date, IFinanceRepository financeRepository) : ICreateFinanceBuilder
{
    private readonly DateTime _date = date;
    private readonly IFinanceRepository _financeRepository = financeRepository;

    public async Task CreateAsync(Mode mode, string sum, Categoria? categoria, Action action)
    {
        if (sum == null && categoria == null)
            return;

        await _financeRepository.Create(mode, Convert.ToDecimal(sum), categoria!, _date);
        action.Invoke();

        ViewBuilder.OnClosePage();
    }
}

public abstract class DateSynchronize
{
    protected IFinanceViewModel _viewModel;
    public DateSynchronize(ref DateTime date, ref IFinanceRepository financeRepository, ref IFinanceViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Date = date;
        _viewModel.FinanceRepository = financeRepository;
    }
}


public class DeleteFinanceBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel) 
    : DateSynchronize(ref date, ref financeRepository, ref viewModel),
    IDeleteFinanceBuilder
{
    public event Action? UpdateElements;
    
    public IFinanceViewModel ViewModel => viewModel;
    public DateTime _date => ViewModel.Date;

    public async Task DeleteAsync(Element element)
    {
        await ViewModel.FinanceRepository.Delete(_date, element!);
        UpdateElements?.Invoke();
    }
}

public class DateChangeBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel)
    : DateSynchronize(ref date, ref financeRepository, ref viewModel),
    IDateChangeBuilder
{
    public event Action? UpdateElements;

    public IFinanceViewModel ViewModel => viewModel;

    public Task DateChangeAsync(DateTime newDate)
    {
        ViewModel.Date = newDate;
        UpdateElements?.Invoke();

        return Task.CompletedTask;
    }
}

public class OpenPageBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel)
    : DateSynchronize(ref date, ref financeRepository, ref viewModel),
    IOpenPageBuilder
{
    public IFinanceViewModel ViewModel => viewModel;

    public async Task OpenCostPageAsync(Action action)
    {
        var addCostViewModel = new AddCostViewModel(ViewModel.Date, ViewModel.FinanceRepository);
        // Подписка на событие
        addCostViewModel.CostAdded += action;
        await Application.Current!.MainPage!.Navigation.PushModalAsync(new AddCostView(addCostViewModel));
    }

    public async Task OpenProfitPageAsync(Action action)
    {
        var addProfitViewModel = new AddProfitViewModel(ViewModel.Date, ViewModel.FinanceRepository);
        // Подписка на событие
        addProfitViewModel.ProfitAdded += action;
        await Application.Current!.MainPage!.Navigation.PushModalAsync(new AddProfitView(addProfitViewModel));
    }
}
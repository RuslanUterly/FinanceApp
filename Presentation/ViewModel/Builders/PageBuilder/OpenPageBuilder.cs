using Data.Interfaces;
using Presentation.View.AddPages;
using Presentation.ViewModel.AddPages;
using Presentation.ViewModel.Builders.PageBuilder.Interface;
using Presentation.ViewModel.MainPages.Intrerfaces;

namespace Presentation.ViewModel.Builders.PageBuilder;

public class OpenPageBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel)
    : DateFinanceSynchronize(ref date, ref financeRepository, ref viewModel),
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
using Data.Interfaces;
using Presentation.ViewModel.Builders.PageBuilder.Interface;
using Presentation.ViewModel.MainPages.Intrerfaces;

namespace Presentation.ViewModel.Builders.PageBuilder;

public class DateChangeBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel)
    : DateFinanceSynchronize(ref date, ref financeRepository, ref viewModel),
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

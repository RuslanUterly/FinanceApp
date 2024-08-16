using Data.Interfaces;
using Presentation.ViewModel.MainPages.Intrerfaces;

namespace Presentation.ViewModel.Builders;

public abstract class DateFinanceSynchronize
{
    protected IFinanceViewModel _viewModel;
    protected DateFinanceSynchronize(ref DateTime date, ref IFinanceRepository financeRepository, ref IFinanceViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Date = date;
        _viewModel.FinanceRepository = financeRepository;
    }
}

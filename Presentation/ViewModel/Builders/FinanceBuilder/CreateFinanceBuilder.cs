using Data.Interfaces;
using Model.DataModel;
using Model.Enum;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;
using Presentation.ViewModel.Builders.PageBuilder;

namespace Presentation.ViewModel.Builders.FinanceBuilder;

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
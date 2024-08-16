using Data.Interfaces;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;
using Presentation.ViewModel.MainPages.Intrerfaces;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel.Builders.FinanceBuilder;

public class DeleteFinanceBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel) 
    : DateFinanceSynchronize(ref date, ref financeRepository, ref viewModel),
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

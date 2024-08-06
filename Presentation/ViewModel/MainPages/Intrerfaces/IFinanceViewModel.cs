using Data.Interfaces;

namespace Presentation.ViewModel.MainPages.Intrerfaces;

public interface IFinanceViewModel
{
    public DateTime Date { get; set; }
    public IFinanceRepository FinanceRepository { get; set; }
}

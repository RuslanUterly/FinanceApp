using Model.DataModel;
using Model.Enum;
using System.Collections.ObjectModel;

namespace Data.Interfaces;

public interface IFinanceRepository
{
    Task<ObservableCollection<Element>> GetAll(DateTime date, Mode mode);
    Task<decimal> GetSum(DateTime date, Mode mode);
    Task Create(Mode mode, decimal cash, Categoria categoria, DateTime date);
    Task Update(DataFinance data);
    Task Delete(DateTime date, Element element);
}

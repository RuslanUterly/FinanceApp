using Data.Model;
using Model.DataModel;
using Model.DataModel.Dto;
using Model.Enum;
using System.Collections.ObjectModel;
using System.Data;

namespace Data.Interfaces;

public interface IFinanceRepository
{
    Task<ObservableCollection<Element>> GetAll(DateTime date, Mode mode);
    Task Create(Mode mode, decimal cash, Categoria categoria, DateTime date);
    Task Update(DataFinance data);
    Task Delete(DateTime date, Element element);
}

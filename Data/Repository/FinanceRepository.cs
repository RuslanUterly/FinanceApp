using Data.Data;
using Data.Extensions;
using Data.Interfaces;
using Model.DataModel;
using Model.Enum;
using System.Collections.ObjectModel;

namespace Data.Repository;

public class FinanceRepository(DataFinanceContext finance) : IFinanceRepository
{
    public readonly DataFinanceContext _finances = finance;

    public Task Create(Mode mode, decimal cash, Categoria categoria, DateTime date)
    {
        if (!_finances.Finance.Any(f => f.DateTime.Date == date.Date)) 
            _finances.Finance.Add(new DataFinance(date, new ObservableCollection<Element>()));

        foreach (var data in _finances.Finance)
        {
            if (date.Date == data.DateTime.Date)
            {
                bool isNewFinance = true;
                foreach (var element in data.Elements!)
                {
                    if (element.Categoria!.Name == categoria.Name && element.Mode == mode)
                    {
                        Element el = element;
                        el.Sum += cash;

                        isNewFinance = false;
                        break;
                    }
                }

                if (isNewFinance)
                {
                    var element = new Element(cash, mode, categoria);
                    data.Elements.Add(element);
                }
            }
        }

        Save();

        return Task.CompletedTask;
    }

    public Task Delete(DateTime date, Element element)
    {
        _finances.Finance.FirstOrDefault(f => f.DateTime.Date == date.Date)!
                         .Elements
                         .Remove(element);

        Save();

        return Task.CompletedTask;
    }

    public Task<ObservableCollection<Element>> GetAll(DateTime date, Mode mode)
    {
        return Task.FromResult(_finances.Finance.Where(f => f.DateTime.Date == date.Date)
                                .SelectMany(f => f.Elements.Where(e => e.Mode == mode))
                                .ToObservableCollection<Element>());
    }

    private void Save() => _finances.UpdateItems();

    public Task Update(DataFinance data)
    {
        return Task.CompletedTask;
    }

    public Task<decimal> GetSum(DateTime date, Mode mode)
    {
        return Task.FromResult(_finances.Finance.Where(f => f.DateTime.Date == date.Date)
                                                .Sum(f => f.Elements.Where(e => e.Mode == mode)
                                                                    .Sum(e => e.Sum)));
    }
}

using Model.DataModel;
using Model.Enum;
using System.Collections.ObjectModel;

namespace Data.Interfaces;

public interface IGroupRepository
{
    ObservableCollection<Element> GetByAllTime(Mode mode);
    Task<(ObservableCollection<Element>, List<DateTime>)> GetByYear(Mode mode, int period);
    Task<(ObservableCollection<Element>, List<DateTime>)> GetByMonth(Mode mode, int period);
    Task<(ObservableCollection<Element>, List<DateTime>)> GetByWeek(Mode mode, int period);
    Task<decimal> GetSum(ObservableCollection<Element> elements);
}

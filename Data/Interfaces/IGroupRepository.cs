using Model.DataModel;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces;

public interface IGroupRepository
{
    ObservableCollection<Element> GetByAllTime(Mode mode);
    Task<(ObservableCollection<Element>, List<DateTime>)> GetByYear(Mode mode, DateTime startDate, int period);
    Task<(ObservableCollection<Element>, List<DateTime>)> GetByMonth(Mode mode, DateTime startDate, int period);
    Task<(ObservableCollection<Element>, List<DateTime>)> GetByWeek(Mode mode, DateTime startDate, int period);
    Task<decimal> GetSum(ObservableCollection<Element> elements);
}

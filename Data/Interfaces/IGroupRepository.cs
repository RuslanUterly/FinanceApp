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
    Task<ObservableCollection<Element>> GetByAllTime(Mode mode);
    Task<ObservableCollection<Element>> GetByYear(Mode mode, DateTime startDate, int period);
    Task<ObservableCollection<Element>> GetByMonth(Mode mode, DateTime startDate, int period);
    Task<ObservableCollection<Element>> GetByWeek(Mode mode, DateTime startDate, int period);
}

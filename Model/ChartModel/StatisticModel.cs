using Model.DataModel;
using System.Collections.ObjectModel;

namespace Model.ChartModel;

public class StatisticModel
{
    public string? DatePeriod { get; set; }
    public string? ResultSum { get; set; }
    public ObservableCollection<Element>? Elements { get; set; }
}

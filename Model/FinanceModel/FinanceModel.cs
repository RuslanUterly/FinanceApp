using Model.DataModel;
using System.Collections.ObjectModel;

namespace Model.FinanceModel;

public class FinanceModel
{
    public ObservableCollection<Element>? Elements { get; set; }
    public string? ElementsSum {  get; set; }
}

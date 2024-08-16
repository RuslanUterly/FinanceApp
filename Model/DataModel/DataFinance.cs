using System.Collections.ObjectModel;

namespace Model.DataModel;

public record DataFinance(DateTime DateTime, ObservableCollection<Element> Elements)
{
    public DataFinance() : this(default, default!)
    {
    }
}



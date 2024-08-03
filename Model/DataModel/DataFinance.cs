using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Model.DataModel;

public record DataFinance(DateTime DateTime, ObservableCollection<Element> Elements)
{
    public DataFinance() : this(default, default)
    {
    }
}



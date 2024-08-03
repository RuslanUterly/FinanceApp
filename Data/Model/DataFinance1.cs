using Model.DataModel;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Data.Model;

public record DataFinance1(DateTime DateTime, ObservableCollection<Element> Elements)
{
    public DataFinance1() : this(default, default)
    {
    }
}



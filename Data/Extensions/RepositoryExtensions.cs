using System.Collections.ObjectModel;

namespace Data.Extensions;

public static class RepositoryExtensions
{
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
    {
        var col = new ObservableCollection<T>();
        foreach (var cur in enumerable)
        {
            col.Add(cur);
        }
        return col;
    }
}

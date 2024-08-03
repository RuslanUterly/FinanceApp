using System.Collections.ObjectModel;
using Data.Data;
using Data.Interfaces;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

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

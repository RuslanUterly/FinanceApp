using Model.DataModel;
using System.Collections.ObjectModel;

namespace FinanceApp.ViewModel.Builders.IconBuilder.Interfaces;

public interface IColorUpdater
{
    Task UpdateColor(ObservableCollection<Categoria> iconCosts, Categoria categoria);
}

using Model.DataModel;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel.Builders.IconBuilder.Interfaces;

public interface IColorUpdater
{
    Task UpdateColor(ObservableCollection<Categoria> iconCosts, Categoria categoria);
}

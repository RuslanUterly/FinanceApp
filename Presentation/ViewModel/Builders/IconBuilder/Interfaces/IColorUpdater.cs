using Model.DataModel;
using Presentation.Model.IconModel;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel.Builders.IconBuilder.Interfaces;

public interface IColorUpdater
{
    Task UpdateColor(ObservableCollection<Categoria> iconCosts, Categoria categoria);
}

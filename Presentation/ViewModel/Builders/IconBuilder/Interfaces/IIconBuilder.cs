using Model.DataModel;
using Model.IconModel;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel.Builders.IconBuilder.Interfaces;

public interface IIconBuilder
{
    Icon Icon { get; set; }
    Categoria? PreviousSelectedItem { get; }
    Categoria? SelectedItem { get; }
    Task ChangeAsync(Categoria item, ObservableCollection<Categoria> IconCosts);
}

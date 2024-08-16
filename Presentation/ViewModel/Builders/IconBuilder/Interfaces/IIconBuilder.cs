using Model.DataModel;
using Model.IconModel;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel.Builders.IconBuilder.Interfaces;

public interface IIconBuilder
{
    IconModel Model { get; set; }
    Categoria? PreviousSelectedItem { get; }
    Categoria? SelectedItem { get; }
    Task ChangeAsync(object sender, ObservableCollection<Categoria> IconCosts);
}

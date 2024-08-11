using Model.DataModel;
using Model.IconModel;
using System.Collections.ObjectModel;

namespace FinanceApp.ViewModel.Builders.IconBuilder.Interfaces;

public interface IIconBuilder
{
    Icon Icon { get; set; }
    Categoria? PreviousSelectedItem { get; }
    Categoria? SelectedItem { get; }
    Task ChangeAsync(object sender, ObservableCollection<Categoria> IconCosts);
}

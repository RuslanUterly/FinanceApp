using Model.DataModel;
using Model.IconModel;
using Presentation.ViewModel.Builders.IconBuilder.Interfaces;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel.Builders.IconBuilder;

public class IconBuilder : IIconBuilder
{
    public IconBuilder()
    {
        Icon = new Icon();
        ColorUpdater = new ColorUpdater();
    }
    public Icon Icon { get; set; }
    public IColorUpdater ColorUpdater { get; private set; }
    public Categoria? PreviousSelectedItem { get; private set; }
    public Categoria? SelectedItem { get; private set; }

    public async Task ChangeAsync(object sender, ObservableCollection<Categoria> IconCosts)
    {
        if (sender is Categoria item)
        {
            SelectedItem = new Categoria(item.Name, item.Icon, item.Color);

            await ColorUpdater.UpdateColor(IconCosts, item);
            await ColorUpdater.UpdateColor(IconCosts, PreviousSelectedItem!);

            PreviousSelectedItem = item;
        }
    }
}

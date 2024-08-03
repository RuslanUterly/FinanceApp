using Model.DataModel;
using Model.IconModel;
using Presentation.Model.IconModel;
using Presentation.ViewModel.Builders.IconBuilder.Interfaces;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel.Builders.IconBuilder;

public class ColorUpdater : IColorUpdater
{
    private readonly IconsColor _iconsColor;

    public ColorUpdater()
    {
        _iconsColor = new IconsColor();
    }

    public Task UpdateColor(ObservableCollection<Categoria> iconCosts, Categoria categoria)
    {
        if (categoria != null)
        {
            // Обновляем цвет категории
            categoria.Color = _iconsColor.Color[categoria.Color];

            // Обновляем элемент в коллекции
            int index = iconCosts.IndexOf(categoria);
            if (index >= 0)
            {
                iconCosts[index] = categoria; // Обновляем элемент в коллекции
            }
        }
        return Task.CompletedTask;
    }
}


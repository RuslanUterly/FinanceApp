using Data.Interfaces;
using Microsoft.Extensions.Primitives;
using Model.DataModel;
using Model.Enum;
using Model.IconModel;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;
using Presentation.ViewModel.Builders.IconBuilder;
using Presentation.ViewModel.Builders.IconBuilder.Interfaces;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel.Builders.FinanceBuilder;

public class FinanceBuilder(DateTime date, IFinanceRepository financeRepository) : IFinanceBuilder
{
    private readonly DateTime _date = date;
    private readonly IFinanceRepository _financeRepository = financeRepository;

    public async Task CreateAsync(Mode mode, string sum, Categoria? categoria)
    {
        if (sum == null && categoria == null)
            return;

        await _financeRepository.Create(mode, Convert.ToDecimal(sum), categoria!, _date);
    }
}

public class ViewBuilder()
{
    public async void OnClosePage() => await Application.Current!.MainPage!.Navigation.PopModalAsync();
}

public class IconBuilder : IIconBuilder
{
    public IconBuilder()
    {
        Icon = new Icon();
        ColorUpdater = new ColorUpdater();
    }
    public Icon Icon {  get; set; }
    public IColorUpdater ColorUpdater {  get; private set; }
    public Categoria? PreviousSelectedItem {  get; private set; }
    public Categoria? SelectedItem { get; private set; }

    public async Task ChangeAsync(Categoria item, ObservableCollection<Categoria> IconCosts)
    {
        SelectedItem = new Categoria(item.Name, item.Icon, item.Color);

        await ColorUpdater.UpdateColor(IconCosts, item);
        await ColorUpdater.UpdateColor(IconCosts, PreviousSelectedItem!);

        PreviousSelectedItem = item;
    }
}

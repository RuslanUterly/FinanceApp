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
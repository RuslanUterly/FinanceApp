﻿using Data.Interfaces;
using Data.Repository;
using Model.DataModel;
using Model.Enum;
using Presentation.View.AddPages;
using Presentation.ViewModel.AddPages;
using Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;
using Syncfusion.Maui.Core.Carousel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel.Builders.FinanceBuilder;

public class CreateFinanceBuilder(DateTime date, IFinanceRepository financeRepository) : ICreateFinanceBuilder
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

public abstract class DateSynchronize
{
    protected IFinanceViewModel _viewModel;
    public DateSynchronize(ref DateTime date, ref IFinanceRepository financeRepository, ref IFinanceViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Date = date;
        _viewModel.FinanceRepository = financeRepository;
    }
}


public class DeleteFinanceBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel) 
    : DateSynchronize(ref date, ref financeRepository, ref viewModel)
{
    public event Action? UpdateElements;
    
    public IFinanceViewModel _viewModel => viewModel;
    public DateTime _date => _viewModel.Date;

    public async Task DeleteAsync(Element element)
    {
        await _viewModel.FinanceRepository.Delete(_date, element!);
        UpdateElements?.Invoke();
    }
}

public class DateChangeBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel)
    : DateSynchronize(ref date, ref financeRepository, ref viewModel)
{
    public event Action? UpdateElements;

    public IFinanceViewModel _viewModel => viewModel;

    public Task DateChangeAsync(DateTime newDate)
    {
        _viewModel.Date = newDate;
        UpdateElements?.Invoke();

        return Task.CompletedTask;
    }
}

public class OpenPageBuilder(DateTime date, IFinanceRepository financeRepository, IFinanceViewModel viewModel)
    : DateSynchronize(ref date, ref financeRepository, ref viewModel)
{
    public IFinanceViewModel _viewModel => viewModel;

    public async Task OpenPageAsync(Action action)
    {
        var addCostViewModel = new AddCostViewModel(_viewModel.Date, _viewModel.FinanceRepository);
        // Подписка на событие
        addCostViewModel.CostAdded += action;
        await Application.Current!.MainPage!.Navigation.PushModalAsync(new AddCostView(addCostViewModel));
    }
}
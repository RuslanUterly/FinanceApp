using Data.Interfaces;
using Model.Enum;
using Presentation.ViewModel.StatisticPages;
using Presentation.ViewModel.StatisticPages.ChartViewModel;
using Syncfusion.Maui.TabView;
using System.Runtime.CompilerServices;

namespace Presentation.View.NavigationPages;

public partial class StatisticCostsView : ContentPage
{
    private readonly IGroupRepository _groupRepository;
    public StatisticCostsView(IGroupRepository groupRepository)
    {
        InitializeComponent();

        _groupRepository = groupRepository;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContext = new StatisticCostsViewModel(_groupRepository);
    }
}
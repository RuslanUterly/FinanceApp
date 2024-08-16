using Data.Interfaces;
using Presentation.ViewModel.StatisticPages;

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
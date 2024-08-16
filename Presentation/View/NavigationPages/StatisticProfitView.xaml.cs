using Data.Interfaces;
using Presentation.ViewModel.StatisticPages;

namespace Presentation.View.NavigationPages;

public partial class StatisticProfitView : ContentPage
{
    private readonly IGroupRepository _groupRepository;
    public StatisticProfitView(IGroupRepository groupRepository)
    {
        InitializeComponent();

        _groupRepository = groupRepository;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContext = new StatisticProfitViewModel(_groupRepository);
    }
}
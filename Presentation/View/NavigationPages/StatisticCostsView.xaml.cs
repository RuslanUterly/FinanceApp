using Data.Interfaces;
using Presentation.ViewModel.StatisticPages;
using Presentation.ViewModel.StatisticPages.ChartViewModel;

namespace Presentation.View.NavigationPages;

public partial class StatisticCostsView : ContentPage
{
    StatisticCostsViewModel viewModel;
    public StatisticCostsView(IGroupRepository groupRepository)
	{
		InitializeComponent();
        BindingContext = viewModel = new StatisticCostsViewModel();
        tabItemAll.BindingContext = new AllTimeViewModel(groupRepository, viewModel);
	}
}
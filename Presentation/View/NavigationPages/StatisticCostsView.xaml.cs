using Data.Interfaces;
using Presentation.ViewModel.StatisticPages;
using Presentation.ViewModel.StatisticPages.ChartViewModel;

namespace Presentation.View.NavigationPages;

public partial class StatisticCostsView : ContentPage
{
	public StatisticCostsView(IFinanceRepository financeRepository)
	{
		InitializeComponent();
		tabItemAll.BindingContext = new AllTimeViewModel(financeRepository);
		BindingContext = new StatisticCostsViewModel();
	}
}
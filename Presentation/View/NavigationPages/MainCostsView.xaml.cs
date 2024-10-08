using Data.Interfaces;
using Presentation.ViewModel;

namespace Presentation.View.NavigationPages;

public partial class MainCostsView : ContentPage
{
    MainCostsViewModel viewModel;
	public MainCostsView(IFinanceRepository financeRepository)
	{
		InitializeComponent();

        BindingContext = viewModel = new MainCostsViewModel(datePicker.Date, financeRepository);
	}

    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (viewModel.DateChangedCommand.CanExecute(datePicker.Date))
        {
            viewModel.DateChangedCommand.Execute(datePicker.Date);
        }
    }
}
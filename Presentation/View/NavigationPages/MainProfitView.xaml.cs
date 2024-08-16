using Data.Interfaces;
using Presentation.ViewModel;

namespace Presentation.View.NavigationPages;

public partial class MainProfitView : ContentPage
{
	MainProfitViewModel viewModel;
	public MainProfitView(IFinanceRepository financeRepository)
	{
        InitializeComponent();

		BindingContext = viewModel = new MainProfitViewModel(datePicker.Date, financeRepository);
	}

    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (viewModel.DateChangedCommand.CanExecute(datePicker.Date))
        {
            viewModel.DateChangedCommand.Execute(datePicker.Date);
        }
    }
}
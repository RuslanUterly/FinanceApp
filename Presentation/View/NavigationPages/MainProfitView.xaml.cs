using Presentation.View.AddPages;
using Presentation.ViewModel;

namespace Presentation.View.NavigationPages;

public partial class MainProfitView : ContentPage
{
	MainProfitViewModel viewModel;
	public MainProfitView()
	{
        InitializeComponent();

		BindingContext = viewModel = new MainProfitViewModel(datePicker.Date, Build.GetFinanceService());
	}

    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (viewModel.DateChangedCommand.CanExecute(datePicker.Date))
        {
            viewModel.DateChangedCommand.Execute(datePicker.Date);
        }
    }
}
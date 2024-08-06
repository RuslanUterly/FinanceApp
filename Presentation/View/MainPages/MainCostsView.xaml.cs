using Presentation.ViewModel;

namespace Presentation.View;

public partial class MainCostsView : ContentPage
{
    MainCostsViewModel viewModel;
	public MainCostsView()
	{
		InitializeComponent();

        BindingContext = viewModel = new MainCostsViewModel(datePicker.Date, Build.GetFinanceService());
	}

    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (viewModel.DateChangedCommand.CanExecute(datePicker.Date))
        {
            viewModel.DateChangedCommand.Execute(datePicker.Date);
        }
    }
}
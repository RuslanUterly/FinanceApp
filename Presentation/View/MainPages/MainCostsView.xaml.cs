using Presentation.ViewModel;

namespace Presentation.View;

public partial class MainCostsView : ContentPage
{
    MainCostsViewModel viewModel;
	public MainCostsView()
	{
		InitializeComponent();

        BindingContext = viewModel = new MainCostsViewModel(datePicker.Date);
	}

    private void SwipeItemView_Invoked(object sender, EventArgs e)
    {
    }

    private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (viewModel.DateChangedCommand.CanExecute(datePicker.Date))
        {
            viewModel.DateChangedCommand.Execute(datePicker.Date);
        }
        //BindingContext = viewModel = new MainCostsViewModel(datePicker.Date);
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        //datePicker_DateSelected(null, null);
    }
}
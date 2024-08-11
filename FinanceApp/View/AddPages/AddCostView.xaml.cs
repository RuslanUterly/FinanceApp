using FinanceApp.ViewModel.AddPages;

namespace FinanceApp.View.AddPages;

public partial class AddCostView : ContentPage
{
	public AddCostView()
	{
		InitializeComponent();
    }

    public AddCostView(AddCostViewModel viewModel) : this()
    {
        BindingContext = viewModel;
    }
}
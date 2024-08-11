using FinanceApp.ViewModel.AddPages;

namespace FinanceApp.View.AddPages;

public partial class AddProfitView : ContentPage
{
	public AddProfitView()
	{
		InitializeComponent();
    }

    public AddProfitView(AddProfitViewModel viewModel) : this()
    {
        BindingContext = viewModel;
    }
}
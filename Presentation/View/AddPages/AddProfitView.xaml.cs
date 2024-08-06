using Presentation.ViewModel.AddPages;

namespace Presentation.View.AddPages;

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
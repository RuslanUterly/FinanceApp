using Presentation.ViewModel.AddPages;

namespace Presentation.View.AddPages;

public partial class AddProfitView : ContentPage
{
	public AddProfitView()
	{
		InitializeComponent();
        BindingContext = new AddProfitViewModel();
    }

    async void ExitPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
using Presentation.View.AddPages;

namespace Presentation.View;

public partial class MainProfitView : ContentPage
{
	public MainProfitView()
	{
		InitializeComponent();
	}

    private void AddProfit_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new AddProfitView());
    }
}
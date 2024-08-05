namespace Presentation.ViewModel.Builders.PageBuilder;

public static class ViewBuilder
{
    public static async void OnClosePage() => await Application.Current!.MainPage!.Navigation.PopModalAsync();
}

namespace FinanceApp.ViewModel.Builders.PageBuilder.Interface;

interface IOpenPageBuilder
{
    public Task OpenCostPageAsync(Action action);
    public Task OpenProfitPageAsync(Action action);
}




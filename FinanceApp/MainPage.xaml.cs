using Data.Data;
using Data.Interfaces;
using Data.Model;
using Data.Repository;

namespace FinanceApp;

public partial class MainPage : ContentPage
{
    string mode = string.Empty;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {

        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<DataFinanceContext>();
        services.AddSingleton<IFinanceRepository, FinanceRepository>();

        var serviceProvider = services.BuildServiceProvider();
        var financeService = serviceProvider.GetRequiredService<IFinanceRepository>();

        //financeService.Create(mode, title.Text, Convert.ToDecimal(cash.Text), DateTime.Now);
        var items = financeService.GetAll(DateTime.Now, Model.Enum.Mode.cost).Result.ToList();

        finance.Text = string.Empty;
        finance.FontSize = 16;

        foreach (var item in items)
        {
            finance.Text += $"{item.Categoria.Name} {item.Sum} {item.Mode} \n";
        }
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton radioButton = sender as RadioButton;

        mode = radioButton.Value.ToString();
    }
}

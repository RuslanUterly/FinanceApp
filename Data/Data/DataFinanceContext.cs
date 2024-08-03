using Data.Model;
using Model.DataModel;
using System.Collections.ObjectModel;
using System.Text.Json;


namespace Data.Data;

public class DataFinanceContext
{
    public ObservableCollection<DataFinance> Finance { get; set; }

    public DataFinanceContext()
    {
        Finance = GetItems();
    }
    //public ObservableCollection<DataFinance> Finance => GetItems();

    public void UpdateItems()
    {
//#if ANDROID
        var docsDirectory = Xamarin.Essentials.FileSystem.CacheDirectory;
        File.Delete(docsDirectory + $"/user.json");

        using (FileStream fs = new FileStream($"{docsDirectory}/user.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<ObservableCollection<DataFinance>>(fs, Finance);
        }
//#endif
    }

    public ObservableCollection<DataFinance> GetItems()
    {
        ObservableCollection<DataFinance> finance = new ObservableCollection<DataFinance>();
//#if ANDROID
        var docsDirectory = Xamarin.Essentials.FileSystem.CacheDirectory;
        using (FileStream fs = new FileStream($"{docsDirectory}/user.json", FileMode.OpenOrCreate))
        {
            if (fs.Length == 0)
            {
                return new ObservableCollection<DataFinance>();
            }

            ObservableCollection<DataFinance> financeTemp = JsonSerializer.Deserialize<ObservableCollection<DataFinance>>(fs)!;

            for (int i = 0; i < financeTemp.Count; i++)
            {
                if (financeTemp[i].Elements!.Count != 0)
                {
                    finance.Add(financeTemp[i]);
                }
            }
        }
//#endif
        if (finance.Count == 0)
        {
            finance.Add(new DataFinance(DateTime.Now, new ObservableCollection<Element>()));
        }

        return finance;
    }

    public ObservableCollection<DataFinance> GetItems(ObservableCollection<DataFinance> dataFinances)
    {
        ObservableCollection<DataFinance> finance = new ObservableCollection<DataFinance>();
//#if ANDROID
        var docsDirectory = Xamarin.Essentials.FileSystem.CacheDirectory;
        using (FileStream fs = new FileStream($"{docsDirectory}/user.json", FileMode.OpenOrCreate))
        {
            if (fs.Length == 0)
            {
                return new ObservableCollection<DataFinance>();
            }

            ObservableCollection<DataFinance> financeTemp = JsonSerializer.Deserialize<ObservableCollection<DataFinance>>(fs)!;

            for (int i = 0; i < financeTemp.Count; i++)
            {
                if (financeTemp[i].Elements!.Count != 0)
                {
                    finance.Add(financeTemp[i]);
                }
            }
        }
//#endif
        if (finance.Count == 0)
        {
            finance.Add(new DataFinance(DateTime.Now, new ObservableCollection<Element>()));
        }

        return dataFinances = finance;
    }
}

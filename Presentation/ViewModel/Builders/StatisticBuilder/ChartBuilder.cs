using Microcharts;
using SkiaSharp;
using System.Collections.ObjectModel;
using Element = Model.DataModel.Element;

namespace Presentation.ViewModel.Builders.StatisticBuilder;

public class ChartBuilder
{
    private List<ChartEntry> SetEntries(ObservableCollection<Element> elements)
    {
        return elements.Select(item => new ChartEntry(Convert.ToInt32(item.Sum))
        {
            Label = item.Categoria!.Name,
            ValueLabel = item.Sum.ToString(),
            Color = SKColor.Parse(item.Categoria.Color),
        }).ToList();
    }

    public Chart Print(ObservableCollection<Element> elements)
    {
        List<ChartEntry> entries = SetEntries(elements);
        
        return new DonutChart()
        {
            Entries = entries,
            LabelTextSize = 35,
            BackgroundColor = SKColor.Parse("#FAFAFA"),
        };
    }
}

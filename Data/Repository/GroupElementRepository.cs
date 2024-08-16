using Data.Data;
using Data.Extensions;
using Data.Interfaces;
using Model.DataModel;
using Model.Enum;
using System.Collections.ObjectModel;

namespace Data.Repository;

public class GroupElementRepository(DataFinanceContext finance) : IGroupRepository
{
    public readonly DataFinanceContext _finances = finance;

    private ElementGrouper grouper => new ElementGrouper();

    public ObservableCollection<Element> GetByAllTime(Mode mode)
    {
        var elements = _finances.Finance.SelectMany(f => f.Elements.Where(e => e.Mode == mode)).ToObservableCollection();

        return grouper.Group(elements);
    }

    public Task<(ObservableCollection<Element>, List<DateTime>)> GetByMonth(Mode mode, int period)
    {
        var dateTimes = new List<DateTime>();

        var startDate = DateTime.Now.AddMonths(-1 + period);
        var endDate = DateTime.Now.AddMonths(period);

        var elements = _finances.Finance.Where(f => f.DateTime >= startDate && f.DateTime <= endDate)
                                        .SelectMany(f => f.Elements.Where(e => e.Mode == mode))
                                        .ToObservableCollection();

        dateTimes.Add(endDate);

        return Task.FromResult((grouper.Group(elements), dateTimes));
    }

    public Task<(ObservableCollection<Element>, List<DateTime>)> GetByWeek(Mode mode, int period)
    {
        var dateTimes = new List<DateTime>();
        var elements = new ObservableCollection<Element>();

        var startDate = DateTime.Now.AddDays(-7 + period);
        var endDate = DateTime.Now.AddDays(period);

        for (DayOfWeek i = DayOfWeek.Sunday; (int)i < 7; i++)
        {
            var items = _finances.Finance.Where(f => f.DateTime >= startDate && f.DateTime <= endDate)
                                         .Where(f => f.DateTime.DayOfWeek == i)
                                         .SelectMany(f => f.Elements.Where(e => e.Mode == mode))
                                         .ToObservableCollection();      

            dateTimes.Add(DateTime.Now.AddDays(-(6 - (double)(i)) + period));

            if (items.Count > 0)
            {
                elements.Add(items.First());
            }
        }

        return Task.FromResult((grouper.Group(elements), dateTimes));
    }

    public Task<(ObservableCollection<Element>, List<DateTime>)> GetByYear(Mode mode, int period)
    {
        var dateTimes = new List<DateTime>();

        var startDate = DateTime.Now.AddYears(-1 + period);
        var endDate = DateTime.Now.AddYears(period);

        var elements = _finances.Finance.Where(x => x.DateTime >= startDate && x.DateTime <= endDate)
                                        .SelectMany(f => f.Elements.Where(e => e.Mode == mode))
                                        .ToObservableCollection();
        dateTimes.Add(endDate);

        return Task.FromResult((grouper.Group(elements), dateTimes));
    }

    public Task<decimal> GetSum(ObservableCollection<Element> elements)
    {
        return Task.FromResult(elements.Sum(e => e.Sum));
    }
}

public class ElementGrouper
{
    public ObservableCollection<Element> Group(ObservableCollection<Element> elements)
    {
        var finalGroup = new ObservableCollection<Element>();
        // Сгруппировать элементы по заголовку
        var groupedElements = elements.GroupBy(x => x.Categoria!.Name);

        foreach (var group in groupedElements)
        {
            // Добавить в final элементы, встречающиеся только один раз
            if (group.Count() == 1)
            {
                finalGroup.Add(group.First()); continue;
            }

            // Суммировать значения для элементов с одинаковым заголовком
            if (group.Count() > 1)
            {
                decimal sum = 0;
                foreach (var element in group)
                {
                    sum += element.Sum;
                }

                // Создать новый элемент со суммированным значением
                Element data = new Element(sum, (Mode)group.First().Mode!, group.First().Categoria!);
                finalGroup.Add(data);
            }
        }
        return finalGroup;
    }
}

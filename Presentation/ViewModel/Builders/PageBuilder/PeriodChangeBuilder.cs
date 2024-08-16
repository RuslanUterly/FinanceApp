using Data.Interfaces;
using Model.Enum;
using Presentation.ViewModel.Builders.PageBuilder.Interface;
using Presentation.ViewModel.StatisticPages.ChartViewModel.Interfaces;


namespace Presentation.ViewModel.Builders.PageBuilder;

public class PeriodChangeBuilder(Mode mode, IGroupRepository groupRepository, IPeriodStatisticViewModel viewModel)
    : DateStatisticSynchronize(ref mode, ref groupRepository, ref viewModel),
    IPeriodChanger
{
    public event Action? StatisticView;

    public Task ForwardPeriod(ref int dateOffset, int offset)
    {
        if (dateOffset == 0)
            return Task.CompletedTask;

        dateOffset += offset;
        StatisticView?.Invoke();

        return Task.CompletedTask;
    }

    public Task BackPeriod(ref int dateOffset, int offset)
    {
        dateOffset -= offset;
        StatisticView?.Invoke();

        return Task.CompletedTask;
    }
}

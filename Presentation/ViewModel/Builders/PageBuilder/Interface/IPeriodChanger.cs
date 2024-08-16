namespace Presentation.ViewModel.Builders.PageBuilder.Interface;

interface IPeriodChanger
{
    event Action StatisticView;
    Task ForwardPeriod(ref int dateOffset, int offset);
    Task BackPeriod(ref int dateOffset, int offset);
}

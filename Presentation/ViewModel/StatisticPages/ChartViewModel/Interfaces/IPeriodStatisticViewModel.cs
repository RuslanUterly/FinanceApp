using Data.Interfaces;
using Model.Enum;

namespace Presentation.ViewModel.StatisticPages.ChartViewModel.Interfaces;

public interface IPeriodStatisticViewModel
{
    IGroupRepository GroupRepository { get; set; }
    Mode Mode { get; set; }
}

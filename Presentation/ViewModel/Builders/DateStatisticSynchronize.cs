using Data.Interfaces;
using Model.Enum;
using Presentation.ViewModel.StatisticPages.ChartViewModel.Interfaces;


namespace Presentation.ViewModel.Builders;

public abstract class DateStatisticSynchronize
{
    protected IPeriodStatisticViewModel _viewModel;
    protected DateStatisticSynchronize(ref Mode mode, ref IGroupRepository groupRepository, ref IPeriodStatisticViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Mode = mode;
        _viewModel.GroupRepository = groupRepository;
    }
}

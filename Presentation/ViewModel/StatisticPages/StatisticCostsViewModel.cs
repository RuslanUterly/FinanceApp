using Data.Interfaces;
using Presentation.ViewModel.StatisticPages.ChartViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Model.Enum;
using System.Text;
using System.Threading.Tasks;
using Element = Model.DataModel.Element;
using Data.Repository;

namespace Presentation.ViewModel.StatisticPages;

public class StatisticCostsViewModel
{
    public StatisticCostsViewModel(IGroupRepository groupRepository)
    {
        AllTimeViewModel = new StatisticAllTimeViewModel(Mode.Cost, groupRepository);
        YearViewModel = new StatisticYearViewModel(Mode.Cost, groupRepository);
    }
    public StatisticAllTimeViewModel AllTimeViewModel { get; }
    public StatisticYearViewModel YearViewModel { get; }
}

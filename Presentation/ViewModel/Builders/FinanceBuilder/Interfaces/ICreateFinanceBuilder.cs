using Model.DataModel;
using Model.Enum;

namespace Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;

interface ICreateFinanceBuilder
{
    Task CreateAsync(Mode mode, string sum, Categoria? categoria);
}

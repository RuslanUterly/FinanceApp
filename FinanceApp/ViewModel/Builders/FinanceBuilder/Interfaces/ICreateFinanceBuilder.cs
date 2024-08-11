using Model.DataModel;
using Model.Enum;

namespace FinanceApp.ViewModel.Builders.FinanceBuilder.Interfaces;

interface ICreateFinanceBuilder
{
    Task CreateAsync(Mode mode, string sum, Categoria? categoria, Action action);
}

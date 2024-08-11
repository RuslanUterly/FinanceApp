using Model.DataModel;
using Model.Enum;
using Element = Model.DataModel.Element;

namespace FinanceApp.ViewModel.Builders.FinanceBuilder.Interfaces;

interface IDeleteFinanceBuilder
{
    public event Action UpdateElements;
    public Task DeleteAsync(Element element);
}





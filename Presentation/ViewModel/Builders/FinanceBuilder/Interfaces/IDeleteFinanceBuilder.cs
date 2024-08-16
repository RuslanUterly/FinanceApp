using Element = Model.DataModel.Element;

namespace Presentation.ViewModel.Builders.FinanceBuilder.Interfaces;

interface IDeleteFinanceBuilder
{
    public event Action UpdateElements;
    public Task DeleteAsync(Element element);
}





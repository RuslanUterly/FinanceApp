namespace Presentation.ViewModel.Builders.PageBuilder.Interface;

interface IDateChangeBuilder
{
    public event Action UpdateElements;
    public Task DateChangeAsync(DateTime newDate);
}




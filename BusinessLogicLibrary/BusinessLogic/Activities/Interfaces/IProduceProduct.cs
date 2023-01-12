using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Activities.Interfaces
{
    public interface IProduceProduct
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}
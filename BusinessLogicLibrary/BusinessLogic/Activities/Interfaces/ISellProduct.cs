using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Activities.Interfaces
{
    public interface ISellProduct
    {
        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, double unitPrice, string doneBy);
    }
}
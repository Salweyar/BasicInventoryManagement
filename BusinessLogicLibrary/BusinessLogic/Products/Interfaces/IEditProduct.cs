using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Products.Interfaces
{
    public interface IEditProduct
    {
        Task ExecuteAsync(Product product);
    }
}
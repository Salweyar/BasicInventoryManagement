using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Products.Interfaces
{
    public interface IAddProduct
    {
        Task ExecuteAsync(Product product);
    }
}
using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Products.Interfaces
{
    public interface IViewProductById
    {
        Task<Product?> ExecuteAsync(int id);
    }
}
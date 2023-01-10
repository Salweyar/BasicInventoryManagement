using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Products.Interfaces
{
    public interface IViewProductByName
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}
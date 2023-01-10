using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Inventories.Interfaces
{
    public interface IViewInventoryById
    {
        Task<Inventory> ExecuteAsync(int Id);
    }
}
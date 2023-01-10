using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Inventories.Interfaces
{
    public interface IAddInventory
    {
        Task ExecuteAsync(Inventory inventory);
    }
}
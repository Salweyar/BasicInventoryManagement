using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Inventories.Interfaces
{
    public interface IEditInvetory
    {
        Task ExecuteAsync(Inventory inventory);
    }
}
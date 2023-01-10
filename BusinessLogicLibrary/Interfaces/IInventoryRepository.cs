using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.Interfaces
{
    public interface IInventoryRepository
    {
        Task AddInventory(Inventory inventory);
        Task EditInventory(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventoriesByName(string name);
        Task<Inventory> GetInventoryByIdAsync(int id);
    }
}
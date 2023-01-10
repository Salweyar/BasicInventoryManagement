using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Inventories.Interfaces
{
    public interface IViewInventoriesByName
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}
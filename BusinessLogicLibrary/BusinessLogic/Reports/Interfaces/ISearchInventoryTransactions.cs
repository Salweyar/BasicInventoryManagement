using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Reports.Interfaces
{
    public interface ISearchInventoryTransactions
    {
        Task<IEnumerable<InventoryTransation>> ExecuteAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType);
    }
}
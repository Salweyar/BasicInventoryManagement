using BusinessLogicLibrary.ViewModels;

namespace BusinessLogicLibrary.BusinessLogic.Activities
{
    public interface IInventorytransationRepository
    {       
        void PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price);

        Task ProduceAsync(string productionNumber, Inventory inventory, int quantity, string doneBy, double price);
        Task<IEnumerable<InventoryTransation>> GetInventoryTransactionsAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType);
    }
}
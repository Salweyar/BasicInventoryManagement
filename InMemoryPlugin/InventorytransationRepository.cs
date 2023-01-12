using BusinessLogicLibrary.BusinessLogic.Activities;
using BusinessLogicLibrary.Interfaces;
using BusinessLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryPlugin
{
    public class InventorytransationRepository : IInventorytransationRepository
    {
        private readonly IInventoryRepository inventoryRepository;
        public List<InventoryTransation> inventoryTransations = new List<InventoryTransation>();

        public async Task<IEnumerable<InventoryTransation>> GetInventoryTransactionsAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType)
        {
            var inventories = (await inventoryRepository.GetInventoriesByName(string.Empty)).ToList();

            var query = from it in this.inventoryTransations
                        join inv in inventories on it.InventoryId equals inv.InventoryId
                        where
                            (string.IsNullOrWhiteSpace(inventoryName) || inv.InventoryName.ToLower().IndexOf(inventoryName.ToLower()) >= 0)
                            &&
                            (!dateFrom.HasValue || it.TransactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || it.TransactionDate <= dateTo.Value.Date) &&
                            (!transactionType.HasValue || it.ActivityType == transactionType)
                        select new InventoryTransation
                        {
                            Inventory = inv,
                            InventoryTransactionId = it.InventoryTransactionId,
                            PONumber = it.PONumber,
                            ProductionNumber = it.ProductionNumber,
                            InventoryId = it.InventoryId,
                            QauntityBefore = it.QauntityBefore,
                            ActivityType = it.ActivityType,
                            QauntityAfter = it.QauntityAfter,
                            TransactionDate = it.TransactionDate,
                            DoneBy = it.DoneBy,
                            UnitPrice = it.UnitPrice
                        };

            return query;
        }

        public Task ProduceAsync(string productionNumber, Inventory inventory, int quantityToConsume, string doneBy, double price)
        {
            this.inventoryTransations.Add(new InventoryTransation
            {
                ProductionNumber = productionNumber,
                InventoryId = inventory.InventoryId,
                QauntityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.ProduceProduct,
                QauntityAfter = inventory.Quantity - quantityToConsume,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            return Task.CompletedTask;
        }

        public void PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price)
        {
            this.inventoryTransations.Add(new InventoryTransation
            {
                PONumber = poNumber,
                InventoryId= inventory.InventoryId,
                QauntityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QauntityAfter= inventory.Quantity + quantity,
                TransactionDate= DateTime.Now,
                DoneBy= doneBy,
                UnitPrice= price
            });
        }
    }
}

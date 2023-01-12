using BusinessLogicLibrary.BusinessLogic.Activities;
using BusinessLogicLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSqlServer
{
    public class InventoryTransactionEFCoreRepository : IInventorytransationRepository
    {
        private readonly IDbContextFactory<DataContext> contextFactory;

        public InventoryTransactionEFCoreRepository(IDbContextFactory<DataContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<InventoryTransation>> GetInventoryTransactionsAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType)
        {
            using var db = contextFactory.CreateDbContext();

            var query = from it in db.InventoryTransactions
                        join inv in db.Inventories on it.InventoryId equals inv.InventoryId
                        where
                            (string.IsNullOrWhiteSpace(inventoryName) || inv.InventoryName.ToLower().IndexOf(inventoryName.ToLower()) >= 0)
                            &&
                            (!dateFrom.HasValue || it.TransactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || it.TransactionDate <= dateTo.Value.Date) &&
                            (!transactionType.HasValue || it.ActivityType == transactionType)
                        select it;

            return await query.Include(x => x.Inventory).ToListAsync();
        }

        public async Task ProduceAsync(string productionNumber, Inventory inventory, int quantityToConsume, string doneBy, double price)
        {
            using var db = contextFactory.CreateDbContext();

            db.InventoryTransactions.Add(new InventoryTransation
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

            await db.SaveChangesAsync();
        }

        public void PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price)
        {
            using var db = contextFactory.CreateDbContext();

            db.InventoryTransactions.Add(new InventoryTransation
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryId,
                QauntityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QauntityAfter = inventory.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            db.SaveChangesAsync();
        }

    }
}

using BusinessLogicLibrary.Interfaces;
using BusinessLogicLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSqlServer
{
    public class InventoryEFCoreRepository : IInventoryRepository
    {
        private readonly IDbContextFactory<DataContext> contextFactory;

        public InventoryEFCoreRepository(IDbContextFactory<DataContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task AddInventory(Inventory inventory)
        {
            using var db = this.contextFactory.CreateDbContext();
            db.Inventories.Add(inventory);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            using var db = this.contextFactory.CreateDbContext();
            return await db.Inventories.Where(
                x => x.InventoryName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            using var db = this.contextFactory.CreateDbContext();
            var inv = await db.Inventories.FindAsync(inventoryId);
            if (inv != null) return inv;

            return new Inventory();
        }

        public async Task EditInventory(Inventory inventory)
        {
            using var db = this.contextFactory.CreateDbContext();
            var inv = await db.Inventories.FindAsync(inventory.InventoryId);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;

                await db.SaveChangesAsync();
            }
        }
    }
}

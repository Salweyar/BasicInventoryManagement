using BusinessLogicLibrary.Interfaces;
using BusinessLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InMemoryPlugin
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory{ InventoryId = 1 , InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
                new Inventory{ InventoryId = 2 , InventoryName = "Bike Body", Quantity = 10, Price = 15 },
                new Inventory{ InventoryId = 3 , InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
                new Inventory{ InventoryId = 4 , InventoryName = "Bike Pedels", Quantity = 20, Price = 1 },
            };
        }

        public Task AddInventory(Inventory inventory)
        {
            if (_inventories.Any(o => o.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _inventories.Max(o => o.InventoryId);
            inventory.InventoryId = maxId + 1;

            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public Task EditInventory(Inventory inventory)
        {
            //if (_inventories.Any(o => o.InventoryId == inventory.InventoryId && o.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            //    return Task.CompletedTask;

            var list = _inventories.FirstOrDefault(o => o.InventoryId == inventory.InventoryId);
            if (list != null)
            {
                list.InventoryName = inventory.InventoryName;
                list.Quantity = inventory.Quantity;
                list.Price = inventory.Price;
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(o => o.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            var inv = _inventories.FirstOrDefault(o => o.InventoryId == id);
            var newInv = new Inventory { InventoryId = inv.InventoryId, InventoryName= inv.InventoryName, Quantity = inv.Quantity, Price = inv.Price };
            return await Task.FromResult(newInv);
        }
    }
}

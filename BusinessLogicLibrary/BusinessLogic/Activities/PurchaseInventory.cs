using BusinessLogicLibrary.BusinessLogic.Activities.Interfaces;
using BusinessLogicLibrary.Interfaces;
using BusinessLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.BusinessLogic.Activities
{
    public class PurchaseInventory : IPurchaseInventory
    {
        private readonly IInventorytransationRepository _inventorytransationRepository;
        private readonly IInventoryRepository _inventory;
        public PurchaseInventory(IInventorytransationRepository inventorytransationRepository, IInventoryRepository inventory)
        {
            _inventorytransationRepository = inventorytransationRepository;
            _inventory = inventory;
        }

        public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
        {
            //insert a record in trasaction table
            _inventorytransationRepository.PurchaseAsync(poNumber, inventory, quantity, doneBy, inventory.Price);

            //increase the quantity
            inventory.Quantity += quantity;
            await _inventory.EditInventory(inventory);
        }
    }
}

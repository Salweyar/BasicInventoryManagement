using BusinessLogicLibrary.BusinessLogic.Inventories.Interfaces;
using BusinessLogicLibrary.Interfaces;
using BusinessLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.BusinessLogic.Inventories
{
    public class EditInvetory : IEditInvetory
    {
        private readonly IInventoryRepository _inventoryRepository;
        public EditInvetory(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(Inventory inventory)
        {
            await _inventoryRepository.EditInventory(inventory);
        }
    }
}

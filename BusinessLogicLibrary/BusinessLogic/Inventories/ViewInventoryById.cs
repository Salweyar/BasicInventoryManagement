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
    public class ViewInventoryById : IViewInventoryById
    {

        private readonly IInventoryRepository _inventory;
        public ViewInventoryById(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }

        public async Task<Inventory> ExecuteAsync(int Id)
        {
            return await _inventory.GetInventoryByIdAsync(Id);
        }

    }
}

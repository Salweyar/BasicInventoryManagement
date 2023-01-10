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
    public class ViewInventoriesByName : IViewInventoriesByName
    {
        private readonly IInventoryRepository _inventory;
        public ViewInventoriesByName(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }

        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await _inventory.GetInventoriesByName(name);
        }
    }
}

using BusinessLogicLibrary.BusinessLogic.Activities;
using BusinessLogicLibrary.BusinessLogic.Reports.Interfaces;
using BusinessLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.BusinessLogic.Reports
{
    public class SearchInventoryTransactions : ISearchInventoryTransactions
    {
        private readonly IInventorytransationRepository inventoryTransactionRepository;

        public SearchInventoryTransactions(IInventorytransationRepository inventoryTransactionRepository)
        {
            this.inventoryTransactionRepository = inventoryTransactionRepository;
        }

        public async Task<IEnumerable<InventoryTransation>> ExecuteAsync(
                string inventoryName,
                DateTime? dateFrom,
                DateTime? dateTo,
                InventoryTransactionType? transactionType
            )
        {
            if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);

            return await this.inventoryTransactionRepository.GetInventoryTransactionsAsync(
                    inventoryName,
                    dateFrom,
                    dateTo,
                    transactionType
                );
        }

    }
}

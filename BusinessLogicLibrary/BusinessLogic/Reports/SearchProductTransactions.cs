using BusinessLogicLibrary.BusinessLogic.Reports.Interfaces;
using BusinessLogicLibrary.Interfaces;
using BusinessLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.BusinessLogic.Reports
{
    public class SearchProductTransactions : ISearchProductTransactions
    {
        private readonly IProductTransactionRepository productTransactionRepository;

        public SearchProductTransactions(IProductTransactionRepository productTransactionRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
        }

        public async Task<IEnumerable<ProductTransaction>> ExecuteAsync(
                string productName,
                DateTime? dateFrom,
                DateTime? dateTo,
                ProductTransactionType? transactionType
            )
        {
            if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);

            return await this.productTransactionRepository.GetProductTransactionsAsync(
                    productName,
                    dateFrom,
                    dateTo,
                    transactionType
                );
        }

    }
}

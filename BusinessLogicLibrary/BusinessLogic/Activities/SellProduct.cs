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
    public class SellProduct : ISellProduct
    {
        private readonly IProductTransactionRepository productTransactionRepository;
        private readonly IProductRepository productRepository;

        public SellProduct(
           IProductTransactionRepository productTransactionRepository,
           IProductRepository productRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, double unitPrice, string doneBy)
        {
            await this.productTransactionRepository.SellProductAsync(salesOrderNumber, product, quantity, unitPrice, doneBy);

            product.Quantity -= quantity;
            await this.productRepository.UpdateProductAsync(product);
        }

    }
}

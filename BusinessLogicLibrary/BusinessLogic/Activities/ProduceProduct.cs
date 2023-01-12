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
    public class ProduceProduct : IProduceProduct
    {
        private readonly IProductTransactionRepository productTransactionRepository;
        private readonly IProductRepository productRepository;

        public ProduceProduct(IProductTransactionRepository productTransactionRepository,
            IProductRepository productRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            //add transaction record
            await this.productTransactionRepository.ProduceAsync(productionNumber, product, quantity, doneBy);

            //decrease the quantity inventories

            //update the quantity of product
            product.Quantity += quantity;
            await this.productRepository.UpdateProductAsync(product);
        }

    }
}

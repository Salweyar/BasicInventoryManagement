using BusinessLogicLibrary.BusinessLogic.Products.Interfaces;
using BusinessLogicLibrary.Interfaces;
using BusinessLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.BusinessLogic.Products
{
    public class AddProduct : IAddProduct
    {
        private readonly IProductRepository _productRepository;

        public AddProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ExecuteAsync(Product product)
        {
            if (product == null) return;

            await _productRepository.AddProductAsync(product);
        }
    }
}

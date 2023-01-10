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
    public class ViewProductById : IViewProductById
    {
        private readonly IProductRepository productRepository;

        public ViewProductById(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product?> ExecuteAsync(int id)
        {
            return await productRepository.GetProductById(id);
        }
    }
}

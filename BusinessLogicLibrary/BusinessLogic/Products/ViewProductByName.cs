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
    public class ViewProductByName : IViewProductByName
    {
        private readonly IProductRepository productRepository;

        public ViewProductByName(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
        {
            return await productRepository.GetProjectByName(name);
        }

    }
}

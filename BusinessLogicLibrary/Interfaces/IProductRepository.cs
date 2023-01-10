using BusinessLogicLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetProjectByName(string name);
        Task UpdateProductAsync(Product product);
    }
}

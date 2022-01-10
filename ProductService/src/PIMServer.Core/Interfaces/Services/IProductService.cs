using PIMServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<IEnumerable<Product>> GetProductByCategory(string category);
        Task<Product> CreateProduct(Product product);
        Task<Object> UpdateProduct(Product product, Guid id);
        Task<bool> DeleteProduct(Guid id);
    }
}

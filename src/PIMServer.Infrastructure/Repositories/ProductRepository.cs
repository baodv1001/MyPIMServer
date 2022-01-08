using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIMServer.Core.Interfaces.Repositories;
using PIMServer.Core.Models;
using PIMServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        public async Task<Product> CreateProduct(Product product)
        {
            var dbProduct = _mapper.Map<Entities.Product>(product);
            await _dbContext.Products.AddAsync(dbProduct);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                // Delete product
                _dbContext.Products.Remove(product);
                // Commit 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _dbContext.Products.ToListAsync().ConfigureAwait(false);
            if (products != null)
            {
                return _mapper.Map<IEnumerable<Product>>(products);
            }
            return null;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                return _mapper.Map<Product>(product);
            }
            return null;
        }

        public async Task<object> UpdateProduct(Product product, Guid id)
        {
            var dbProduct = await _dbContext.Products.FindAsync(id);

            if (dbProduct == null || dbProduct.Id != id)
            {
                return new { message = "Not found!" };
            }
            // Handle concurrency
            if (dbProduct.UpdatedAt != product.UpdatedAt)
            {
                return new { message = "Product has been updated, please refresh the page!" };
            }
            dbProduct.Name = product.Name;
            dbProduct.UpdatedAt = DateTime.Now;

            // Update product
            _dbContext.Products.Update(dbProduct);
            //Commit
            await _dbContext.SaveChangesAsync();
            return new { message = "Update success!", product = dbProduct };
        }
    }
}

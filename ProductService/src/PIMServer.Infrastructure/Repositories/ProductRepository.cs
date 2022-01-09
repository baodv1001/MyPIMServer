using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIMServer.Core.Interfaces.Repositories;
using PIMServer.Core.Models;
using PIMServer.Infrastructure.Context;
using PIMServer.Infrastructure.Entities;
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
        private readonly StoreProductDbContext _storeDbContext;
        private readonly IMapper _mapper;
        public async Task<Core.Models.Product> CreateProduct(Core.Models.Product product)
        {
            var dbProduct = _mapper.Map<Entities.Product>(product);
            var storeDbProduct = _mapper.Map<Entities.StoreProduct>(product);
            await _dbContext.Products.AddAsync(dbProduct);
            await _dbContext.SaveChangesAsync();
            await _storeDbContext.StoreProducts.AddAsync(storeDbProduct);
            await _storeDbContext.SaveChangesAsync();
            return _mapper.Map<Core.Models.Product>(dbProduct);
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

        public async Task<IEnumerable<Core.Models.Product>> GetAllProducts()
        {
            var products = await _dbContext.Products.ToListAsync().ConfigureAwait(false);
            if (products != null)
            {
                return _mapper.Map<IEnumerable<Core.Models.Product>>(products);
            }
            return null;
        }

        public async Task<Core.Models.Product> GetProductById(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                return _mapper.Map<Core.Models.Product>(product);
            }
            return null;
        }

        public async Task<object> UpdateProduct(Core.Models.Product product, Guid id)
        {
            var dbProduct = await _dbContext.Products.FindAsync(id);
            Category category = dbProduct.Category;
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
            var storeDbProduct = _mapper.Map<Entities.StoreProduct>(dbProduct);
            await _storeDbContext.StoreProducts.AddAsync(storeDbProduct);
            //Commit
            await _dbContext.SaveChangesAsync();
            await _storeDbContext.SaveChangesAsync();
            return new { message = "Update success!", product = dbProduct };
        }
    }
}

using Microsoft.Extensions.Logging;
using PIMServer.Core.Interfaces.Repositories;
using PIMServer.Core.Interfaces.Services;
using PIMServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product));
                }
                return await _productRepository.CreateProduct(product);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error while trying to call Create Product in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            try
            {
                return await _productRepository.DeleteProduct(id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error while trying to call Delete Product in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                /*throw new ArgumentNullException();*/
                return await _productRepository.GetAllProducts();

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error while trying to call Get All Products in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            try
            {
                return await _productRepository.GetProductByCategory(category);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error while trying to call Get Products by category in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Product> GetProductById(Guid id)
        {
            try
            {
                return await _productRepository.GetProductById(id);

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error while trying to call Get Product By Id in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<object> UpdateProduct(Product product, Guid id)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product));
                }
                return await _productRepository.UpdateProduct(product, id);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error while trying to call Update Product in service class, Error Message = {ex}.");
                throw;
            }
        }
    }
}

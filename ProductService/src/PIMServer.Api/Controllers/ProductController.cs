using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIMServer.Core.Interfaces.Services;
using PIMServer.Core.Models;

namespace PIMServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService ?? throw new ArgumentNullException(nameof(ProductService));
        }

        // Get All Products
        // Return List Products
        // Table used: Products
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var response = await _productService.GetAllProducts().ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Get an Product by Id
        // Return an Product
        // Table used: Products
        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _productService.GetProductById(id).ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Create Product
        // Return an Product created
        // Table used: Products
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _productService.CreateProduct(product).ConfigureAwait(false);

            return CreatedAtRoute(nameof(GetProductById), new { id = response.Id }, response);
        }

        // Delete Product
        // Return true/false
        // Table used: Products
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteProduct(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return await _productService.DeleteProduct(id).ConfigureAwait(false);
        }

        // Delete Product
        // Return true/false
        // Table used: Products
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Object>> UpdateProduct(Product product, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _productService.UpdateProduct(product, id).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

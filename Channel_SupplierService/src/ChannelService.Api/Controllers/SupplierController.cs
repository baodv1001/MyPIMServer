using ChannelService.Core.Interfaces.Services;
using ChannelService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChannelService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
        }

        // Get All Suppliers
        // Return List Suppliers
        // Table used: Suppliers
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetCategories()
        {
            var response = await _supplierService.GetAllSuppliers().ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Get an Supplier by Id
        // Return an Supplier
        // Table used: Suppliers
        [HttpGet("{id}", Name = "GetSupplierById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Models.Supplier>> GetSupplierById(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _supplierService.GetSupplierById(id).ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Create Supplier
        // Return an Supplier created
        // Table used: Suppliers
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Models.Supplier>> CreateSupplier(Core.Models.Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _supplierService.CreateSupplier(supplier).ConfigureAwait(false);

            return CreatedAtRoute(nameof(GetSupplierById), new { id = response.Id }, response);
        }

        // Delete Supplier
        // Return true/false
        // Table used: Suppliers
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteSupplier(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return await _supplierService.DeleteSupplier(id).ConfigureAwait(false);
        }

        // Delete Supplier
        // Return true/false
        // Table used: Suppliers
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> UpdateSupplier(Core.Models.Supplier supplier, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _supplierService.UpdateSupplier(supplier, id).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

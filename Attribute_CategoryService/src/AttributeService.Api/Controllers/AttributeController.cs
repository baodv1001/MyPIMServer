using AttributeService.Core.Interfaces.Services;
using AttributeService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttributeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IAttributeService _productService;
        public AttributeController(IAttributeService AttributeService)
        {
            _productService = AttributeService ?? throw new ArgumentNullException(nameof(AttributeService));
        }

        // Get All Attributes
        // Return List Attributes
        // Table used: Attributes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Core.Models.Attribute>>> GetAttributes()
        {
            var response = await _productService.GetAllAttributes().ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Get an Attribute by Id
        // Return an Attribute
        // Table used: Attributes
        [HttpGet("{id}", Name = "GetAttributeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Models.Attribute>> GetAttributeById(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _productService.GetAttributeById(id).ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Create Attribute
        // Return an Attribute created
        // Table used: Attributes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Models.Attribute>> CreateAttribute(Core.Models.Attribute product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _productService.CreateAttribute(product).ConfigureAwait(false);

            return CreatedAtRoute(nameof(GetAttributeById), new { id = response.Id }, response);
        }

        // Delete Attribute
        // Return true/false
        // Table used: Attributes
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAttribute(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return await _productService.DeleteAttribute(id).ConfigureAwait(false);
        }

        // Delete Attribute
        // Return true/false
        // Table used: Attributes
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> UpdateAttribute(Core.Models.Attribute product, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _productService.UpdateAttribute(product, id).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

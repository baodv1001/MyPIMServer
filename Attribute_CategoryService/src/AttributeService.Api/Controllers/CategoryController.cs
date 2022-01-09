using AttributeService.Core.Interfaces.Services;
using AttributeService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttributeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService ?? throw new ArgumentNullException(nameof(CategoryService));
        }

        // Get All Categorys
        // Return List Categorys
        // Table used: Categorys
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Core.Models.Category>>> GetCategories()
        {
            var response = await _categoryService.GetAllCategories().ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Get an Category by Id
        // Return an Category
        // Table used: Categorys
        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Models.Category>> GetCategoryById(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _categoryService.GetCategoryById(id).ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Create Category
        // Return an Category created
        // Table used: Categorys
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Models.Category>> CreateCategory(Core.Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _categoryService.CreateCategory(category).ConfigureAwait(false);

            return CreatedAtRoute(nameof(GetCategoryById), new { id = response.Id }, response);
        }

        // Delete Category
        // Return true/false
        // Table used: Categorys
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteCategory(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return await _categoryService.DeleteCategory(id).ConfigureAwait(false);
        }

        // Delete Category
        // Return true/false
        // Table used: Categorys
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> UpdateCategory(Core.Models.Category category, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _categoryService.UpdateCategory(category, id).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

using AssetsService.Core.Interfaces.Services;
using AssetsService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsService _assetService;
        public AssetsController(IAssetsService assetService)
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
        }

        // Get All Assets
        // Return List Assets
        // Table used: Assets
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Assets>>> GetAssets()
        {
            var response = await _assetService.GetAllAssets().ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Get an Asset by Id
        // Return an Asset
        // Table used: Assets
        [HttpGet("{id}", Name = "GetAssetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Assets>> GetAssetById(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _assetService.GetAssetById(id).ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Create Asset
        // Return an Asset created
        // Table used: Assets
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Assets>> CreateAsset(Assets Asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _assetService.CreateAsset(Asset).ConfigureAwait(false);

            return CreatedAtRoute(nameof(GetAssetById), new { id = response.Id }, response);
        }

        // Delete Asset
        // Return true/false
        // Table used: Assets
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsset(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return await _assetService.DeleteAsset(id).ConfigureAwait(false);
        }

        // Delete Asset
        // Return true/false
        // Table used: Assets
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> UpdateAsset(Assets Asset, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _assetService.UpdateAsset(Asset, id).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

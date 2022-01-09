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

        // Get an Asset by url
        // Return an Asset
        // Table used: Assets
        [HttpGet("{url}", Name = "GetAssetByUrl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<byte[]>> GetAssetByUrl (string url)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _assetService.GetAssetByUrl(url).ConfigureAwait(false);
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
        public Byte[] ConvertFileToBytes(File file)
        {
            Byte[] asset = new Byte[]();
            //handle conver at here

            return asset;
        }

        public async Task<ActionResult<string>> CreateAsset(File file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Assets asset = new Assets();
            asset.Data = ConvertFileToBytes(file);
            // Generate URL
            //Code here
            var response = await _assetService.CreateAsset(asset).ConfigureAwait(false);

            return response;
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

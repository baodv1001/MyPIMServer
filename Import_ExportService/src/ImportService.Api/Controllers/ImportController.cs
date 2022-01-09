using ImportService.Core.Interfaces.Services;
using ImportService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImportService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IImportService _importService;
        public ImportController(IImportService importService)
        {
            _importService = importService ?? throw new ArgumentNullException(nameof(importService));
        }


        
        // Create Import
        // Return an Import created
        // Table used: Imports
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ImportFile(ImportFile Import)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _importService.Import(Import).ConfigureAwait(false);
            return Ok();
        }

    }
}

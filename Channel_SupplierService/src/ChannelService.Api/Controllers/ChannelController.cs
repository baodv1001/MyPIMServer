using ChannelService.Core.Interfaces.Services;
using ChannelService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChannelService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _ChannelService;
        public ChannelController(IChannelService ChannelService)
        {
            _ChannelService = ChannelService ?? throw new ArgumentNullException(nameof(ChannelService));
        }

        // Get All Channels
        // Return List Channels
        // Table used: Channels
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Core.Models.Channel>>> GetChannels()
        {
            var response = await _ChannelService.GetAllChannels().ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Get an Channel by Id
        // Return an Channel
        // Table used: Channels
        [HttpGet("{id}", Name = "GetChannelById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Models.Channel>> GetChannelById(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _ChannelService.GetChannelById(id).ConfigureAwait(false);
            return response == null ? NoContent() : Ok(response);
        }

        // Create Channel
        // Return an Channel created
        // Table used: Channels
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Models.Channel>> CreateChannel(Core.Models.Channel Channel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _ChannelService.CreateChannel(Channel).ConfigureAwait(false);

            return CreatedAtRoute(nameof(GetChannelById), new { id = response.Id }, response);
        }

        // Delete Channel
        // Return true/false
        // Table used: Channels
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteChannel(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return await _ChannelService.DeleteChannel(id).ConfigureAwait(false);
        }

        // Delete Channel
        // Return true/false
        // Table used: Channels
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> UpdateChannel(Core.Models.Channel Channel, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _ChannelService.UpdateChannel(Channel, id).ConfigureAwait(false);

            return response == null ? NoContent() : Ok(response);
        }
    }
}

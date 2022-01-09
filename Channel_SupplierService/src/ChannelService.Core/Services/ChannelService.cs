using ChannelService.Core.Interfaces.Services;
using ChannelService.Core.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelService.Core.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _channelRepository;
        private readonly ILogger<ChannelService> _logger;
        public ChannelService(IChannelRepository channelRepository, ILogger<ChannelService> logger)
        {
            _channelRepository = channelRepository ?? throw new ArgumentNullException(nameof(channelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Models.Channel> CreateChannel(Models.Channel channel)
        {
            try
            {
                if (channel == null)
                {
                    throw new ArgumentNullException(nameof(channel));
                }
                return await _channelRepository.CreateChannel(channel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Create Channel in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<bool> DeleteChannel(Guid id)
        {
            try
            {
                return await _channelRepository.DeleteChannel(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Delete Channel in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Models.Channel>> GetAllChannels()
        {
            try
            {
                /*throw new ArgumentNullException();*/
                return await _channelRepository.GetAllChannels();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Get All Channels in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Models.Channel> GetChannelById(Guid id)
        {
            try
            {
                return await _channelRepository.GetChannelById(id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Get Channel By Id in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<object> UpdateChannel(Models.Channel channel, Guid id)
        {
            try
            {
                if (channel == null)
                {
                    throw new ArgumentNullException(nameof(channel));
                }
                return await _channelRepository.UpdateChannel(channel, id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Update Channel in service class, Error Message = {ex}.");
                throw;
            }
        }
    }
}

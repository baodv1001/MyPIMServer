using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelService.Infrastructure.Context;
using ChannelService.Infrastructure.Entities;
using ChannelService.Core.Models;
using ChannelService.Core.Interfaces.Repositories;

namespace ChannelService.Infrastructure.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly ChannelDbContext _dbContext;
        private readonly IMapper _mapper;
        public async Task<Core.Models.Channel> CreateChannel(Core.Models.Channel channel)
        {
            var dbChannel = _mapper.Map<Entities.Channel>(channel);
            await _dbContext.Channels.AddAsync(dbChannel);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Core.Models.Channel>(dbChannel);
        }

        public async Task<bool> DeleteChannel(Guid id)
        {
            var channel = await _dbContext.Channels.FindAsync(id);
            if (channel != null)
            {
                // Delete channel
                _dbContext.Channels.Remove(channel);
                // Commit 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Core.Models.Channel>> GetAllChannels()
        {
            var channels = await _dbContext.Channels.ToListAsync().ConfigureAwait(false);
            if (channels != null)
            {
                return _mapper.Map<IEnumerable<Core.Models.Channel>>(channels);
            }
            return null;
        }

        public async Task<Core.Models.Channel> GetChannelById(Guid id)
        {
            var channel = await _dbContext.Channels.FindAsync(id);
            if (channel != null)
            {
                return _mapper.Map<Core.Models.Channel>(channel);
            }
            return null;
        }

        public async Task<object> UpdateChannel(Core.Models.Channel channel, Guid id)
        {
            var dbChannel = await _dbContext.Channels.FindAsync(id);

            if (dbChannel == null || dbChannel.Id != id)
            {
                return new { message = "Not found!" };
            }
            // Handle concurrency
            if (dbChannel.UpdatedAt != channel.UpdatedAt)
            {
                return new { message = "Channel has been updated, please refresh the page!" };
            }
            dbChannel.Name = channel.Name;
            dbChannel.UpdatedAt = DateTime.Now;

            // Update channel
            _dbContext.Channels.Update(dbChannel);
            //Commit
            await _dbContext.SaveChangesAsync();
            return new { message = "Update success!", channel = dbChannel };
        }
    }
}

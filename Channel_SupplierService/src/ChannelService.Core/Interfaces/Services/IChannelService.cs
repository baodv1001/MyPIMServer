using ChannelService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelService.Core.Interfaces.Services
{
    public interface IChannelService
    {
        Task<IEnumerable<Channel>> GetAllChannels();
        Task<Channel> GetChannelById(Guid id);
        Task<Channel> CreateChannel(Channel channel);
        Task<object> UpdateChannel(Channel channel, Guid id);
        Task<bool> DeleteChannel(Guid id);
    }
}

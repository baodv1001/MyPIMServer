using ChannelService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelService.Core.Interfaces.Repositories
{
    public interface IChannelRepository
    {
        Task<IEnumerable<Models.Channel>> GetAllChannels();
        Task<Models.Channel> GetChannelById(Guid id);
        Task<Models.Channel> CreateChannel(Models.Channel attribute);
        Task<object> UpdateChannel(Models.Channel attribute, Guid id);
        Task<bool> DeleteChannel(Guid id);
    }
}

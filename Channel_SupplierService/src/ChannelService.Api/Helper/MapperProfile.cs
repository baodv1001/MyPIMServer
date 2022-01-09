using AutoMapper;
using ChannelService.Infrastructure.Entities;

namespace 
    Service.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Channel, ChannelService.Core.Models.Channel>().ReverseMap();
            CreateMap<Supplier, ChannelService.Core.Models.Supplier>().ReverseMap();
        }
    }
}

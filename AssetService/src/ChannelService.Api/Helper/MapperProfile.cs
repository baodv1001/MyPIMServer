using AssetsService.Infrastructure.Entities;
using AutoMapper;

namespace
    Service.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Assets, AssetsService.Core.Models.Assets>().ReverseMap();
        }
    }
}

using AutoMapper;

namespace PIMServer.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Infrastructure.Entities.Product, Core.Models.Product>().ReverseMap();
            CreateMap<Infrastructure.Entities.Language, Core.Models.Language>().ReverseMap();
        }
    }
}

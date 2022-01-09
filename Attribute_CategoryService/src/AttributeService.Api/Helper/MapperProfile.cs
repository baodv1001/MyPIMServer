using AutoMapper;

namespace AttributeService.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Infrastructure.Entities.Product, Core.Models.Product>().ReverseMap();
            CreateMap<Infrastructure.Entities.Category, Core.Models.Category>().ReverseMap();
            CreateMap<Infrastructure.Entities.Attribute, Core.Models.Attribute>().ReverseMap();
            CreateMap<Infrastructure.Entities.AttributeGroup, Core.Models.AttributeGroup>().ReverseMap();
            CreateMap<Infrastructure.Entities.Attribute_Product, Core.Models.Attribute_Product>().ReverseMap();
        }
    }
}

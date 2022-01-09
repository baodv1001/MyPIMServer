using AutoMapper;
using ImportService.Infrastructure.Entities;
using ImportService.Core.Models;

namespace ImportService.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Infrastructure.Entities.ImportFile, Core.Models.ImportFile>().ReverseMap();
        }
    }
}

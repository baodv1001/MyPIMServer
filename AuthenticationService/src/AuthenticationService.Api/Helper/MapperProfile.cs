using AuthService.Infrastructure.Entities;
using AutoMapper;

namespace AuthenticationService.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, AuthenticationService.Core.Models.User>().ReverseMap();
            CreateMap<Role, AuthenticationService.Core.Models.Role>().ReverseMap();
        }
    }
}

using AutoMapper;
using Core.DTOs;
using Core.Entities.UserIdentity;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterCredentialsDTO, ApplicationUser>();
        }
    }
}

using AutoMapper;
using Core.DTOs;
using Core.Entities.UserIdentity;

namespace Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterCredentialsDTO, ApplicationUser>();
        }
    }
}

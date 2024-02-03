using AutoMapper;
using Core.DTOs;
using Core.Models;

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

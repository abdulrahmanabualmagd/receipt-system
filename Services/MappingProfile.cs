using AutoMapper;
using Core.DTOs;
using Core.Models;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterCredentialsDTO, User>();
        }
    }
}

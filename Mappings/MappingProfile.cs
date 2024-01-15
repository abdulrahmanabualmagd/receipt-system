using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MVC_Core.DTOs;
using MVC_Core.Models;

namespace MVC_Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterCredentialsDTO, User>();
        }
    }
}

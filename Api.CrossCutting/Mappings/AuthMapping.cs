using Api.Domain.Dtos.Auth;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class AuthMapping : Profile
    {
        public AuthMapping()
        {
            CreateMap<AuthDtoCreate, AuthEntity>().ReverseMap();
            CreateMap<AuthDtoCreate, WorkshopEntity>().ReverseMap();
        }
    }
}
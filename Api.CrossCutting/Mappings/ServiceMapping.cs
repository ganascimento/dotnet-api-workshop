using Api.Domain.Dtos.Service;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<ServiceDto, ServiceEntity>().ReverseMap();
        }
    }
}
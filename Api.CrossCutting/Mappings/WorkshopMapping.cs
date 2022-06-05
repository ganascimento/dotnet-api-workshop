using Api.Domain.Dtos.Workshop;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class WorkshopMapping : Profile
    {
        public WorkshopMapping()
        {
            CreateMap<WorkshopDto, WorkshopEntity>().ReverseMap();
            CreateMap<WorkshopDtoUpdate, WorkshopEntity>().ReverseMap();
            CreateMap<WorkshopDtoUpdateResult, WorkshopEntity>().ReverseMap();
        }
    }
}
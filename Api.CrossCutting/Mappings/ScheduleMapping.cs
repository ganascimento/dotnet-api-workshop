using Api.Domain.Dtos.Schedule;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ScheduleMapping : Profile
    {
        public ScheduleMapping()
        {
            CreateMap<ScheduleDto, ScheduleEntity>().ReverseMap();
            CreateMap<ScheduleDtoCreate, ScheduleEntity>().ReverseMap();
            CreateMap<ScheduleDtoCreateResult, ScheduleEntity>().ReverseMap();
        }
    }
}
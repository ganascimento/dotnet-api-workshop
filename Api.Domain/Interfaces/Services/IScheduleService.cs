using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Schedule;

namespace Api.Domain.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleDto>> GetToday();
        Task<IEnumerable<ScheduleDto>> GetPeriod();
        Task<IEnumerable<ScheduleDto>> GetPeriod(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ScheduleDtoAvailableWorkLoad>> GetAvailableWorkLoad();
        Task<ScheduleDtoCreateResult> Create(ScheduleDtoCreate dto);
        Task<bool> Remove(int id);
    }
}
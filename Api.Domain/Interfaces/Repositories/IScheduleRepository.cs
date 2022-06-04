using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories.Base;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IScheduleRepository : IRepository<ScheduleEntity>
    {
        Task<IEnumerable<ScheduleEntity>> SelectPeriodAsync(DateTime date);
        Task<IEnumerable<ScheduleEntity>> SelectPeriodAsync(DateTime startDate, DateTime endDate);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Context;
using Api.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Repositories
{
    public class ScheduleRepository : Repository<ScheduleEntity>, IScheduleRepository
    {
        private DbSet<ScheduleEntity> _dataset;

        public ScheduleRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<ScheduleEntity>();
        }

        public async Task<IEnumerable<ScheduleEntity>> SelectPeriodAsync(int workshopId, DateTime date)
        {
            try
            {
                return await _dataset.Where(p => p.WorkshopId.Equals(workshopId) && p.Date.Equals(date)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ScheduleEntity>> SelectPeriodAsync(int workshopId, DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _dataset.Where(p => p.WorkshopId.Equals(workshopId) && p.Date >= startDate && p.Date <= endDate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
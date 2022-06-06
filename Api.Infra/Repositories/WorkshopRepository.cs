using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Context;
using Api.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Repositories
{
    public class WorkshopRepository : Repository<WorkshopEntity>, IWorkshopRepository
    {
        private DbSet<WorkshopEntity> _dataset;
        public WorkshopRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<WorkshopEntity>();
        }

        public async Task<WorkshopEntity> SelectByAuthIdAsync(int id)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.AuthId.Equals(id));
        }
    }
}
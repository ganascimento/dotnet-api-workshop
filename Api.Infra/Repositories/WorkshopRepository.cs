using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Context;
using Api.Infra.Repositories.Base;

namespace Api.Infra.Repositories
{
    public class WorkshopRepository : Repository<WorkshopEntity>, IWorkshopRepository
    {
        public WorkshopRepository(DataContext context) : base(context)
        {
        }
    }
}
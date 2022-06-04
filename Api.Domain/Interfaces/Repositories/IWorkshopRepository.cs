using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories.Base;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IWorkshopRepository : ICommandRepository<WorkshopEntity>, IQueryRepository<WorkshopEntity>
    {
    }
}
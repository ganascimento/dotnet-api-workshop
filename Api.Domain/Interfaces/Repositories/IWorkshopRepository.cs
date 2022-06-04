using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories.Base;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IWorkshopRepository : IRepository<WorkshopEntity>
    {
        Task<WorkshopEntity> SelectByAuthIdAsync(int id);
    }
}
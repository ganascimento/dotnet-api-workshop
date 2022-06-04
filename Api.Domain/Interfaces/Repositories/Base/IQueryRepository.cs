using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities.Base;

namespace Api.Domain.Interfaces.Repositories.Base
{
    public interface IQueryRepository<T> where T : BaseEntity
    {
        Task<T> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAsync();
    }
}
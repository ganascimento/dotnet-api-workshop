using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities.Base;

namespace Api.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAsync();
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
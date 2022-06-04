using System.Threading.Tasks;
using Api.Domain.Entities.Base;

namespace Api.Domain.Interfaces.Repositories.Base
{
    public interface ICommandRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
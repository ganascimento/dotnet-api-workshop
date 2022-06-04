using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories.Base;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IAuthRepository : ICommandRepository<AuthEntity>, IQueryRepository<AuthEntity>
    {
        Task<bool> Exists(string cnpj);
    }
}
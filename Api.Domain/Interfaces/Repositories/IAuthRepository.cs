using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories.Base;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IAuthRepository : IRepository<AuthEntity>
    {
        Task<bool> Exists(string cnpj);
    }
}
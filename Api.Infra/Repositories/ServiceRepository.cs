using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Context;
using Api.Infra.Repositories.Base;

namespace Api.Infra.Repositories
{
    public class ServiceRepository : Repository<ServiceEntity>, IServiceRepository
    {
        public ServiceRepository(DataContext context) : base(context)
        {
        }
    }
}
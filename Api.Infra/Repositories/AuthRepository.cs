using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Context;
using Api.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Repositories
{
    public class AuthRepository : Repository<AuthEntity>, IAuthRepository
    {
        private DbSet<AuthEntity> _dataset;

        public AuthRepository(DataContext context) : base(context)
        {
            _dataset = context.Set<AuthEntity>();
        }

        public async Task<bool> Exists(string cnpj) {
            try
            {
                return await _dataset.AnyAsync(p => p.Cnpj.Equals(cnpj));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities.Base;
using Api.Domain.Interfaces.Repositories.Base;
using Api.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private DbSet<T> _dataset;
        public Repository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> SelectAsync(int id)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<T> InsertAsync(T item)
        {
            item.CreateAt = DateTime.UtcNow;
            _dataset.Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
            if (result == null)
                return null;

            item.UpdateAt = DateTime.UtcNow;
            item.CreateAt = result.CreateAt;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (result == null)
                return false;

            _dataset.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientMangementApi.PensionManagement.Infrastructure.Repository;

namespace PatientMangementApi.PensionManagement.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                .Where(e => EF.Property<bool>(e, "IsDeleted") == false)
                                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            var isDeletedProperty = typeof(T).GetProperty("IsDeleted");
            if (isDeletedProperty != null && (bool)isDeletedProperty.GetValue(entity))
            {
                return null;
            }

            return entity;
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            else
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                var isDeletedProperty = entity.GetType().GetProperty("IsDeleted");
                if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
                {
                    isDeletedProperty.SetValue(entity, true);
                    var numOfRowsAffected = await _context.SaveChangesAsync();
                    return numOfRowsAffected > 0;
                }
            }
            return false;
        }

        public async Task HardDeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            var isDeletedProperty = typeof(T).GetProperty("IsDeleted");
            return isDeletedProperty == null || !(bool)isDeletedProperty.GetValue(entity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

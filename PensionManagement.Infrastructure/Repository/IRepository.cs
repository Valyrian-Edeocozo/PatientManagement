using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientMangementApi.PensionManagement.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task HardDeleteAsync(int id);
        
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Care.MedicineInventory.Service.Entities;

namespace Care.MedicineInventory.Service.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}
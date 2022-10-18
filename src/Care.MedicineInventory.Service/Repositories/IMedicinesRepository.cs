using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Care.MedicineInventory.Service.Entities;

namespace Care.MedicineInventory.Service.Repositories
{
    public interface IMedicinesRepository
    {
        Task CreateAsync(Medicine entity);
        Task<IReadOnlyCollection<Medicine>> GetAllAsync();
        Task<Medicine> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Medicine entity);
    }
}
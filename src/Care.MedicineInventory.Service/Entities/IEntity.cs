using System;

namespace Care.MedicineInventory.Service.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
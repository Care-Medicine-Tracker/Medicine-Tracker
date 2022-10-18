using System;
using Care.Common;

namespace Care.MedicineInventory.Service.Entities
{

    public class Medicine : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
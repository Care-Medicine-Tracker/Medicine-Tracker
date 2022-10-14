using System;

namespace Care.MedicineInventory.Service.Entities
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
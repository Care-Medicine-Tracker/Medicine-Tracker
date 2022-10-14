using Care.MedicineInventory.Service.Dtos;
using Care.MedicineInventory.Service.Entities;

namespace Care.MedicineInventory.Service
{
    //all extensions methods should be static
    public static class Extensions
    {
        //return medicine entity as medicine Dto
        public static MedicineDto AsDto(this Medicine medicine)
        {
            return new MedicineDto(medicine.Id, medicine.Name, medicine.Description, medicine.CreatedDate);
        }
    }
}
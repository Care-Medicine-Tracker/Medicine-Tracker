using System;

namespace Care.MedicineInventory.Service.Dtos
{
    //DTO for GET operations
    public record MedicineDto(Guid Id, string Name, string Description, DateTimeOffset CreatedDate);

    //DTO for POST (creation of medication) operations
    //There is no ID or DateTime variable due to the reason that it will be autogenerated
    public record CreateMedicineDto(Guid Id, string Name, string Description, DateTimeOffset CreatedDate);

    //DTO for UPDATE operations
    //There is no ID or DateTime variable due to the reason that it will be autogenerated
    public record UpdateMedicineDto(Guid Id, string Name, string Description, DateTimeOffset CreatedDate);
}
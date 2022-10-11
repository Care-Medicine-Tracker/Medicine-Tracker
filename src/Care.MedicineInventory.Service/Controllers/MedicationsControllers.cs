using System;
using System.Collections.Generic;
using System.Linq;
using Care.MedicineInventory.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Care.MedicineInventory.Service.Controller
{
    //API controller attribute is to improve the rest api developer experience.
    [ApiController]
    //Route "https:localhost:5001/medications" will be handled by this controller.
    [Route("medications")]
    // each of the webapi controllers should be derived from ControllerBase
    // the ControllerBase provides many properties and methods for handling HTTP requests
    public class ItemsController : ControllerBase
    {
        private static readonly List<MedicineDto> medicines = new()
        {
            new MedicineDto(Guid.NewGuid(), "Melatonin", "Helps with falling asleep", DateTimeOffset.UtcNow),
            new MedicineDto(Guid.NewGuid(), "Melatonin", "Helps with falling asleep", DateTimeOffset.UtcNow),
            new MedicineDto(Guid.NewGuid(), "Melatonin", "Helps with falling asleep", DateTimeOffset.UtcNow)
        };

        // returns list of registered medications
        [HttpGet]
        public IEnumerable<MedicineDto> Get()
        {
            return medicines;
        }

        // returns specified medication
        [HttpGet("{id}")]
        public MedicineDto GetById(Guid id)
        {
            var medicine = medicines.Where(medicine => medicine.Id == id).SingleOrDefault();
            return medicine;
        }

        //creates medication
        [HttpPost]
        public ActionResult<MedicineDto> Post(CreateMedicineDto createMedicineDto)
        {
            var medicine = new MedicineDto(Guid.NewGuid(), createMedicineDto.Name, createMedicineDto.Description, DateTimeOffset.UtcNow);
            medicines.Add(medicine);
            return CreatedAtAction(nameof(GetById), new { id = medicine.Id }, medicine);
        }
    }
}
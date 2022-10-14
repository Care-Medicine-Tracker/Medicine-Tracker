using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Care.MedicineInventory.Service.Dtos;
using Care.MedicineInventory.Service.Entities;
using Care.MedicineInventory.Service.Repositories;
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
        private readonly MedicinesRepository medicineRepository = new();

        // returns list of registered medications
        [HttpGet]
        public async Task<IEnumerable<MedicineDto>> GetAsync()
        {
            var medicines = (await medicineRepository.GetAllAsync())
                            .Select(medicine => medicine.AsDto());
            return medicines;
        }

        // returns specified medication
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicineDto>> GetByIdAsync(Guid id)
        {
            var medicine = await medicineRepository.GetAsync(id);

            if (medicine == null)
            {
                return NotFound();
            }

            return medicine.AsDto();
        }

        //creates medication
        [HttpPost("{id}")]
        public async Task<ActionResult<MedicineDto>> PostAsync(CreateMedicineDto createMedicineDto)
        {
            var medicine = new Medicine
            {
                Name = createMedicineDto.Name,
                Description = createMedicineDto.Description,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await medicineRepository.CreateAsync(medicine);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = medicine.Id }, medicine);
        }

        //Put updating medication info
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateMedicineDto updateMedicineDto)
        {
            var existingMedicine = await medicineRepository.GetAsync(id);

            if (existingMedicine == null)
            {
                return NotFound();
            }

            existingMedicine.Name = updateMedicineDto.Name;
            existingMedicine.Description = updateMedicineDto.Description;
            existingMedicine.CreatedDate = updateMedicineDto.CreatedDate;

            await medicineRepository.UpdateAsync(existingMedicine);

            return NoContent();
        }

        //Delete medication
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var medicine = await medicineRepository.GetAsync(id);

            if (medicine == null)
            {
                return NotFound();
            }

            await medicineRepository.RemoveAsync(medicine.Id);

            return NoContent();
        }
    }
}
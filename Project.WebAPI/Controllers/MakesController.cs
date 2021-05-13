using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Entities;
using Project.Model;
using Project.Service.Common;
using Project.WebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;

        public MakesController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }

        //[Route("GetAll")]
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    FilterMake filter = new FilterMake();
        //    SortMake sort = new SortMake();
        //    Paging<VehicleMake> paging = new Paging<VehicleMake>();
        //    var makeList = await vehicleMakeService.FindAsync(filter, sort, paging); // mozda find mora biti drugaciji ovdje, da ga ipak promijenim da bude bez sort, fiter i paginga?

        //    var list = mapper.Map<VehicleMakeDto[]>(makeList.ToList()); // ovo sam dodala da mi se prikaz drugacije vidi
        //    return Ok(list);
        //}

        [Route("Get/{id}", Name = "Get")]
        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {

            var makeItem = mapper.Map<VehicleMakeDto>(await vehicleMakeService.GetAsync(id));
            if (makeItem == null)
            {
                return NotFound();
            }
            return Ok(makeItem);    // mapirati u DTO
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleMakeDto newMakeDto)
        {
            var newMake = await vehicleMakeService.CreteAsync(mapper.Map<VehicleMake>(newMakeDto));

            var readMakeDto = mapper.Map<VehicleMakeDto>(newMake);


            return CreatedAtRoute(nameof(Get), new { Id = readMakeDto.Id }, readMakeDto);
        }

        //[Route("Put/{id}")]
        [HttpPut("{id}")] // OVO MI NE RADI- ISPRAVI!

        public async Task<IActionResult> Update(int id, VehicleMakeDto updatedMakeDto)
        {
            var selectedMake = await vehicleMakeService.GetAsync(id);
            if (selectedMake == null)
            {
                return NotFound();
            }
            var updatedMake = await vehicleMakeService.UpdateAsync(mapper.Map<VehicleMake>(updatedMakeDto));
            return Ok(mapper.Map<VehicleMakeDto>(updatedMake));
        }

        //[HttpPatch("{id}")] // NI OVAJ MI NE RADI... MALO RAZMISLI O PROMJENI OVIH METODA ILI UpdateMake metode iz Servicea!
        //public async Task<IActionResult> PartialUpdate(int id, JsonPatchDocument<VehicleMakeDto> patchDoc)
        //{
        //    var selectedMake = await vehicleMakeService.GetAsync(id);
        //    if (selectedMake == null)
        //    {
        //        return NotFound();
        //    }

        //    var makeToPatch = mapper.Map<VehicleMakeDto>(selectedMake);
        //    patchDoc.ApplyTo(makeToPatch, ModelState);

        //    if (!TryValidateModel(makeToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    var updatedMake = await vehicleMakeService.UpdateAsync(mapper.Map<VehicleMakeEntity>(makeToPatch));

        //    return NoContent();
        //}
        [Route("Delete/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var selectedMake = await vehicleMakeService.GetAsync(id);
            if (selectedMake == null)
            {
                return NotFound();
            }
            var deletedMake = await vehicleMakeService.DeleteAsync(id);

            return NoContent();

        }
    }
}

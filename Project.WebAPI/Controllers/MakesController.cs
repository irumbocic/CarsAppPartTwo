using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Entities;
using Project.Model;
using Project.Service.Common;
using Project.WebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;

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

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery(Name = "Search")] string SearchString,
            [FromQuery(Name = "Sort")] string SortBy,
            [FromQuery(Name = "page")] int page

            )
        {
            //FilterMake filter = new FilterMake();
            //SortMake sort = new SortMake();
            //Paging<VehicleMake> paging = new Paging<VehicleMake>();
            //var makeList = await vehicleMakeService.FindAsync(filter, sort, paging); // mozda find mora biti drugaciji ovdje, da ga ipak promijenim da bude bez sort, fiter i paginga?

            var list = await vehicleMakeService.FindAsync(SearchString, SortBy, page); // ovo sam dodala da mi se prikaz drugacije vidi

            var mappedList = mapper.Map<List<VehicleMakeDto>>(list);

            return Ok(list);
        }

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

        [Route("UpdateMake/{id}")]
        [HttpPut("{id}")]  // NE RADI!! SKUZITI ZASTO 

        public async Task<IActionResult> UpdateMake(int id, VehicleMakeDto updatedMakeDto)
        {
            var selectedMake = await vehicleMakeService.GetAsync(id);
            
            if (selectedMake == null)
            {
                return NotFound();
            }

            mapper.Map(updatedMakeDto, selectedMake);
            await vehicleMakeService.UpdateAsync(selectedMake);
            return Ok();
        }


        [Route("Update/{id}")]
        [HttpPatch] // NE radi, moram skuziti kako se detacha entity, zasto mu to smeta, mogu li na neki drugi nacin Update Repository metodu napraviti...
        public async Task<IActionResult> Update(int id, JsonPatchDocument<VehicleMakeDto> patchDoc)
        {
            var selectedMake = await vehicleMakeService.GetAsync(id);
            if (selectedMake == null)
            {
                return NotFound();
            }

            var makeToPatch = mapper.Map<VehicleMakeDto>(selectedMake);
            patchDoc.ApplyTo(makeToPatch, ModelState);

            if (!TryValidateModel(makeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            var itemForUpdate = mapper.Map<VehicleMake>(makeToPatch);

            var updatedMake = await vehicleMakeService.UpdateAsync(itemForUpdate);

            return NoContent();
        }


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

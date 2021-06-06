using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Common;
using Project.WebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Project.Model;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IMapper mapper;

        public ModelsController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this.vehicleModelService = vehicleModelService;
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

            var list = await vehicleModelService.FindAsync(SearchString, SortBy, page); // ovo sam dodala da mi se prikaz drugacije vidi

            var mappedList = mapper.Map<List<VehicleModelDto>>(list);
            return Ok(mappedList);
        }

        [Route("Get/{id}", Name = "GetModel")] // Ovaj RouteAttribute --> Name ne smije biti isti tu i kod Make-a, PAZI - STAVI KOD MAKE-a GetMake, da bude isto kao i ovdje
        [HttpGet]
        public async Task<IActionResult> GetModel(int id)
        {
            var modelItem = mapper.Map<VehicleModelDto>(await vehicleModelService.GetAsync(id));
            if (modelItem == null)
            {
                return NotFound();
            }
            return Ok(modelItem);
        }

        [HttpPost] // NE RADI --> PROVJERITI ZASTO :/ UPdate: Radi ali baca neku gresku --> provjeriti!
        public async Task<IActionResult> Create(VehicleModelDto newModelDto)
        {
            var newModel = await vehicleModelService.CreteAsync(mapper.Map<VehicleModel>(newModelDto));

            var readModelDto = mapper.Map<VehicleMakeDto>(newModel);

            return Ok();
            //return CreatedAtRoute(nameof(GetModel), new { Id = readModelDto.Id }, readModelDto);
        }


        [Route("Delete/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var selectedModel = await vehicleModelService.GetAsync(id);
            if (selectedModel == null)
            {
                return NotFound();
            }
            var deletedMake = await vehicleModelService.DeleteAsync(id);

            return NoContent();

        }

    }
}

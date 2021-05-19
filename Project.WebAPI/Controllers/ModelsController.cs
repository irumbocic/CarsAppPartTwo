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

        [Route("Get/{id}", Name = "GetModel")] // Ovaj RouteAttribute --> Name ne smije biti isti tu i kod Make-a
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

        //[HttpPost]
        //public async Task<IActionResult> Post(VehicleModelDto newModelDto)
        //{
        //    // OVO NIJE OK!!!! Moram srediti kako dodati MakeID/VehicleMake za model koji dodajem/kreiram

        //    var newModel = await vehicleModelService.CreateModelAsync(mapper.Map<VehicleModel>(newModelDto));

        //    var readModelDto = mapper.Map<VehicleModelDto>(newModel);

        //    return CreatedAtRoute(nameof(GetModel), new { Id = readModelDto.Id }, readModelDto);

        //}

    }
}

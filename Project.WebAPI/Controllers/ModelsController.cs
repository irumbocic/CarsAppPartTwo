using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ModelsController : ControllerBase
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IMapper mapper;

        public ModelsController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
        }

        //[Route("GetAll")]
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    Filter filter = new Filter();
        //    Sort sort = new Sort();
        //    Paging<VehicleModel> paging = new Paging<VehicleModel>();

        //    var modelList = await vehicleModelService.FindAsync(filter, sort, paging);

        //    var list = mapper.Map<VehicleModelDto[]>(modelList).ToList();
        //    IPagedList<VehicleModelDto> pagedViewModelList = new StaticPagedList<VehicleModelDto>(list, modelList.GetMetaData());

        //    return Ok(pagedViewModelList);
        //}

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

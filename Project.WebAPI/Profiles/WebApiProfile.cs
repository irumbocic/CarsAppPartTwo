using Project.DAL.Entities;
using Project.Model;
using Project.WebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Model.Common;

namespace Project.WebAPI.Profiles
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            //VehicleMake
            CreateMap<VehicleMake, VehicleMakeDto>()
               .ReverseMap();
            CreateMap<VehicleMakeEntity, VehicleMakeDto>()
              .ReverseMap();
            CreateMap<VehicleMake, VehicleMakeEntity>()
              .ReverseMap();
            CreateMap<IVehicleMake, VehicleMakeDto>()
               .ReverseMap();

            //VehicleModel
            CreateMap<VehicleModel, VehicleModelDto>()
               .ReverseMap();
            CreateMap<VehicleModelEntity, VehicleModelDto>()
              .ReverseMap();
            CreateMap<VehicleModel, VehicleModelEntity>()
              .ReverseMap();
            CreateMap<IVehicleModel, VehicleModelDto>()
               .ReverseMap();

        }
    }
}

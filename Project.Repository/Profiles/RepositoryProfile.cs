using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;

namespace Project.Repository
{
    public class RepositoryProfile : Profile
    {
        public RepositoryProfile()
        {
            
            CreateMap<VehicleModel, VehicleModelEntity>()
              .ReverseMap();
            CreateMap<VehicleMake, VehicleMakeEntity>()
              .ReverseMap();
            CreateMap<VehicleMake, IVehicleMake>()
              .ReverseMap();
            CreateMap<VehicleModel, IVehicleModel>()
              .ReverseMap();

            //CreateMap<List<VehicleModel>, List<VehicleModelEntity>>()
            // .ReverseMap();

            //CreateMap<List<VehicleMake>, List<VehicleMakeEntity>>()
            //.ReverseMap();
        }
    }

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<RepositoryProfile>();
            });
        }
    }
}

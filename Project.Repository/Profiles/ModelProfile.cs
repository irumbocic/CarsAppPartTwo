using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.DAL.Entities;
using Project.Model;


namespace Project.Repository
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            
            CreateMap<VehicleModel, VehicleModelEntity>()
              .ReverseMap();
            CreateMap<VehicleMake, VehicleMakeEntity>()
              .ReverseMap();
        }
    }
}

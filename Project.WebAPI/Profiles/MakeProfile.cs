using Project.DAL.Entities;
using Project.Model;
using Project.WebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;


namespace Project.WebAPI.Profiles
{
    public class MakeProfile : Profile
    {
        public MakeProfile()
        {
            CreateMap<VehicleMake, VehicleMakeDto>()
               .ReverseMap();
            CreateMap<VehicleMakeEntity, VehicleMakeDto>()
              .ReverseMap();
            CreateMap<VehicleMake, VehicleMakeEntity>()
              .ReverseMap();
        }
    }
}

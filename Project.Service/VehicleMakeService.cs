using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
//using X.PagedList;
//using Service.PageSortFilter;
using System.Linq;
using Project.Repository;
using Project.Service.Common;
using Project.Model;
//using AutoMapper;
using Project.DAL.Entities;
using Project.Repository.Repository;
using Project.Model.Common;
using AutoMapper;
using Project.DAL;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleMakeRepository repository;
        private readonly IMapper mapper;

        public VehicleMakeService(VehicleMakeRepository repository, IMapper mapper, VehicleContext context)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<VehicleMake> CreteAsync(VehicleMake newItem)
        {
            var newItemEntity = await repository.CreteAsync(mapper.Map<VehicleMakeEntity>(newItem));

            return mapper.Map<VehicleMake>(newItemEntity);
        }
        public async Task<VehicleMake> DeleteAsync(int id)
        {

            var deleteItem = repository.repository.context.VehicleMakes.FirstOrDefault(m => m.Id == id);
            return mapper.Map<VehicleMake>(await repository.DeleteAsync(deleteItem.Id));

        }

        public async Task<VehicleMake> GetAsync(int id)
        {

            var getItem = repository.repository.context.VehicleMakes.FirstOrDefault(m => m.Id == id);
            return mapper.Map<VehicleMake>(await repository.GetAsync(getItem.Id));
            
        }

        public async Task<VehicleMake> UpdateAsync(VehicleMake updatedItem)
        {
            var updatedItemEntity = await repository.UpdateAsync(mapper.Map<VehicleMakeEntity>(updatedItem));
            return mapper.Map<VehicleMake>(updatedItemEntity);
        }

    }
}

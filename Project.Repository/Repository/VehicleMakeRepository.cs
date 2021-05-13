using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Repository

{

    public class VehicleMakeRepository : IVehicleMakeRepository
    {

        public VehicleRepository<VehicleMakeEntity> repository;

        public VehicleMakeRepository(VehicleRepository<VehicleMakeEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<VehicleMakeEntity> CreteAsync(VehicleMakeEntity newItem)
        {

            return await repository.CreteAsync(newItem);
        }
        public async Task<VehicleMakeEntity> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<VehicleMakeEntity> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<VehicleMakeEntity> UpdateAsync(VehicleMakeEntity updatedItem)
        {
            return await repository.UpdateAsync(updatedItem);
        }
    }
}

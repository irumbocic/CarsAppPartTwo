using Project.DAL.Entities;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        public VehicleRepository<VehicleModelEntity> repository;

        public VehicleModelRepository(VehicleRepository<VehicleModelEntity> repository)
        {
            this.repository = repository;
        }


        public async Task<VehicleModelEntity> CreteAsync(VehicleModelEntity newItem)
        {

            return await repository.CreteAsync(newItem);
        }
        public async Task<VehicleModelEntity> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<VehicleModelEntity> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<VehicleModelEntity> UpdateAsync(VehicleModelEntity updatedItem)
        {
            return await repository.UpdateAsync(updatedItem);
        }
    }
}

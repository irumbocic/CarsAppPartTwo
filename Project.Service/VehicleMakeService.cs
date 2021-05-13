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

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleMakeRepository repository;

        public VehicleMakeService(VehicleMakeRepository repository)
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

using Project.DAL.Entities;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.Repository.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        public VehicleRepository<VehicleModelEntity> repository;

        public VehicleModelRepository(VehicleRepository<VehicleModelEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<List<VehicleModelEntity>> FindAsync(string SearhcString, string SortBy, int? queryPage)
        {

            var query = (from models
                         in repository.context.VehicleModels.Include(make => make.VehicleMake)
                         select models);

            if (!string.IsNullOrEmpty(SearhcString))
            {
                query = query.Where(m => m.Name.Contains(SearhcString) || m.Abrv.Contains(SearhcString) || m.VehicleMake.Name.Contains(SearhcString));
            }


            switch (SortBy) //probaj dodati VehicleMake Name ovdje
            {
                case "Name":
                    query = query.OrderBy(m => m.Name);
                    break;
                case "Abrv":
                    query = query.OrderBy(m => m.Abrv);
                    break;
                default:
                    query = query.OrderBy(m => m.Id);
                    break;
            }

            int perPage = 10;
            int page = queryPage.GetValueOrDefault(1) == 0 ? 1 : queryPage.GetValueOrDefault(1);
            int total = query.Count();

            return await query.Skip((page - 1) * perPage).Take(perPage).ToListAsync();
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

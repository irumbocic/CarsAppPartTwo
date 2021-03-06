using Project.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<VehicleModelEntity> CreteAsync(VehicleModelEntity newItem);
        Task<VehicleModelEntity> DeleteAsync(int id);
        Task<VehicleModelEntity> GetAsync(int id);
        Task<VehicleModelEntity> UpdateAsync(VehicleModelEntity updatedItem);

        Task<List<VehicleModelEntity>> FindAsync(string SearhcString, string SortBy, int? queryPage);
    }
}
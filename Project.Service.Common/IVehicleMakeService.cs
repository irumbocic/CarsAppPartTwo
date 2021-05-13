using Project.DAL.Entities;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<VehicleMakeEntity> CreteAsync(VehicleMakeEntity newItem);
        Task<VehicleMakeEntity> DeleteAsync(int id);
        Task<VehicleMakeEntity> GetAsync(int id);
        Task<VehicleMakeEntity> UpdateAsync(VehicleMakeEntity updatedItem);
    }
}
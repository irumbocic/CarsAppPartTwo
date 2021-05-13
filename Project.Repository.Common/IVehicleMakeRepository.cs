using Project.DAL.Entities;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<VehicleMakeEntity> CreteAsync(VehicleMakeEntity newItem);
        Task<VehicleMakeEntity> DeleteAsync(int id);
        Task<VehicleMakeEntity> GetAsync(int id);
        Task<VehicleMakeEntity> UpdateAsync(VehicleMakeEntity updatedItem);
    }
}
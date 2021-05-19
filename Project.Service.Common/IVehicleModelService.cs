using Project.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<VehicleModel> CreteAsync(VehicleModel newItem);
        Task<VehicleModel> DeleteAsync(int id);
        Task<VehicleModel> GetAsync(int id);
        Task<VehicleModel> UpdateAsync(VehicleModel updatedItem);

        Task<List<VehicleModel>> FindAsync(string SearchString, string SortBy, int? queryPage);
    }
}
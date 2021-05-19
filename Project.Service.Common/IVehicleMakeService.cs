using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<VehicleMake> CreteAsync(VehicleMake newItem);
        Task<VehicleMake> DeleteAsync(int id);
        Task<VehicleMake> GetAsync(int id);
        Task<VehicleMake> UpdateAsync(VehicleMake updatedItem);
        Task<List<VehicleMake>> FindAsync(string SearchString, string SortBy, int? queryPage);
        public void Detach(VehicleMake item);

    }
}
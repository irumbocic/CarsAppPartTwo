using Project.DAL.Entities;
using Project.Repository.Common;
using System.Threading.Tasks;

namespace Project.Repository.Repository
{
    public interface IUnitOfWork
    {
        IVehicleMakeRepository makeRepository { get; set; }
        IVehicleModelRepository modelRepository { get; set; }

        Task<VehicleModelEntity> CreateAsync(VehicleModelEntity newModel, VehicleMakeEntity newMake);
    }
}
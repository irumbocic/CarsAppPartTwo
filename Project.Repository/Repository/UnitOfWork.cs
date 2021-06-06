using Project.DAL.Entities;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IVehicleMakeRepository makeRepository { get; set; }
        public IVehicleModelRepository modelRepository { get; set; }

#nullable enable
        public async Task<VehicleModelEntity> CreateAsync(VehicleModelEntity newModel, VehicleMakeEntity? newMake)
        {
            if (newMake != null)
            {
                await makeRepository.CreteAsync(newMake);
            }

            await modelRepository.CreteAsync(newModel);

            return newModel;
        }
#nullable disable

    }
}

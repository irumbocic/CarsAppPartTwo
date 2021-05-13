using System.Collections.Generic;

namespace Project.Model.Common
{
    public interface IVehicleMake
    {
        string Abrv { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}